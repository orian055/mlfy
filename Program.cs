var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// CORS middleware
app.UseCors("AllowAll");

// Root redirect
app.MapGet("/", (HttpContext ctx) =>
{
    ctx.Response.Redirect("/Yas");
    return Task.CompletedTask;
});

// Static files - serves wwwroot and public assets
app.UseStaticFiles(new Microsoft.AspNetCore.Builder.StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "",
    OnPrepareResponse = ctx =>
    {
        // Set cache headers for static files
        if (ctx.File.Name.EndsWith(".css") || ctx.File.Name.EndsWith(".js") || 
            ctx.File.Name.EndsWith(".png") || ctx.File.Name.EndsWith(".jpg"))
        {
            ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=31536000");
        }
        // Service worker shouldn't be cached aggressively
        else if (ctx.File.Name.EndsWith("sw.js") || ctx.File.Name.EndsWith("manifest.json"))
        {
            ctx.Context.Response.Headers.Add("Cache-Control", "public, max-age=3600");
        }
    }
});

// ========== MAIN HOME PAGE ==========
app.MapGet("/Yas", () =>
{
    return Results.Content("""
    <html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0, viewport-fit=cover, user-scalable=no, maximum-scale=1">
        <meta name="theme-color" content="#0f1b2e">
        <meta name="description" content="A beautiful love website built with care">
        <meta name="apple-mobile-web-app-capable" content="yes">
        <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
        <meta name="apple-mobile-web-app-title" content="Love Portal">
        <meta name="format-detection" content="telephone=no">
        <meta name="apple-itunes-app" content="app-id=0">
        <link rel="manifest" href="/manifest.json">
        <link rel="icon" href="/yasmin-Photoroom.png" type="image/png">
        <link rel="apple-touch-icon" href="/yasmin-Photoroom.png" type="image/png">
        <link rel="mask-icon" href="/icon.svg" color="#ffffff">
        <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
        <style>
            :root {
                --rose: #ffffff; --rose-light: #a3c4ff; --rose-dark: #7ea7ff;
                --gold: #4a7dcc; --gold-light: #7ca9ff;
                --cream: #e8f1ff; --deep: #0f1b2e; --wine: #15254b; --soft-pink: #ffffff;
            }
            * { box-sizing: border-box; margin: 0; padding: 0; }
            body {
                min-height: 100vh;
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                background: linear-gradient(135deg, #08101e 0%, #141e2a 100%);
                overflow-x: hidden;
            }
            .bg-canvas {
                position: fixed; inset: 0;
                background:
                    radial-gradient(ellipse at 10% 20%, rgba(255,255,255,0.1) 0%, transparent 50%),
                    radial-gradient(ellipse at 90% 80%, rgba(42,61,84,0.3) 0%, transparent 45%),
                    linear-gradient(160deg, #0a1520 0%, #141e2a 40%, #0a1520 100%);
                z-index: 0;
            }
            .petal {
                position: fixed; pointer-events: none;
                animation: petalFall linear infinite; z-index: 1; opacity: 0.2;
            }
            @keyframes petalFall {
                0%   { transform: translateY(-60px) rotate(0deg); opacity: 0.25; }
                50%  { transform: translateY(50vh) rotate(180deg) translateX(30px); opacity: 0.15; }
                100% { transform: translateY(110vh) rotate(360deg) translateX(-15px); opacity: 0; }
            }

            /* ג”€ג”€ LAYOUT ג”€ג”€ */
            .layout { display: flex; min-height: 100vh; position: relative; z-index: 2; }

            /* ג”€ג”€ SIDEBAR ג”€ג”€ */
            .sidebar {
                width: 180px; flex-shrink: 0;
                display: flex; flex-direction: column;
                padding: 36px 16px;
                padding-top: max(36px, env(safe-area-inset-top));
                padding-left: max(16px, env(safe-area-inset-left));
                padding-right: max(16px, env(safe-area-inset-right));
                background: linear-gradient(180deg, rgba(16,30,56,0.94) 0%, rgba(15,25,44,0.92) 100%);
                border-right: 2px solid rgba(124,169,255,0.16);
                backdrop-filter: blur(8px);
                position: sticky; top: 0; height: 100vh; overflow-y: auto;
            }
            .logo-wrap { display: flex; flex-direction: column; align-items: center; margin-bottom: 16px; justify-content: flex-start; }
            .logo-frame {
                width: 72px; height: 72px; border-radius: 50%;
                border: 3px solid #ffffff; padding: 3px;
                box-shadow: 0 4px 16px rgba(255,255,255,0.15);
                cursor: pointer;
            }
            .logo-frame img { width: 100%; height: 100%; border-radius: 50%; object-fit: cover; display: block; }
            .logo-name {
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; font-size: 1rem;
                color: #ffffff; margin-top: 8px; letter-spacing: 0.05em;
                text-shadow: none; text-align: center;
            }
            .divider {
                width: 55%; height: 2px;
                background: linear-gradient(90deg, transparent, #ffffff, transparent);
                margin: 4px auto 20px;
                display: none;
            }
            .nav-label {
                font-size: 0.7rem; letter-spacing: 0.22em; text-transform: uppercase;
                color: #7ca9ff; opacity: 0.85; margin-bottom: 10px; text-align: center;
                display: block;
            }
            .nav-grid {
                display: flex;
                flex-direction: column;
                gap: 10px;
                margin-bottom: 18px;
            }
            .meter {
                width: 100%; display: flex; flex-direction: column; gap: 12px;
                padding: 16px 14px; border-radius: 18px;
                background: rgba(10,26,50,0.88);
                border: 1px solid rgba(124,169,255,0.16);
                box-shadow: 0 20px 50px rgba(5,11,24,0.35);
            }
            .meter-title {
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                font-size: 0.75rem; letter-spacing: 0.16em; text-transform: uppercase;
                color: rgba(124,169,255,0.92);
            }
            .meter-track {
                position: relative; width: 100%; height: 10px;
                background: rgba(255,255,255,0.08); border-radius: 999px;
                overflow: hidden;
            }
            .meter-fill {
                width: 0%; height: 100%; border-radius: 999px;
                background: linear-gradient(90deg, rgba(124,169,255,0.95), rgba(255,255,255,0.9));
                transition: width 0.45s ease;
            }
            .meter-details {
                display: flex; justify-content: space-between; gap: 10px;
                font-size: 0.88rem; color: rgba(225,235,255,0.9);
            }
            .meter-percent { font-weight: 700; }
            .meter-count { color: rgba(124,169,255,0.75); }
            .nav-btn {
                width: 100%; padding: 13px 18px;
                border-radius: 12px; border: 2px solid rgba(84,103,146,0.6);
                background: rgba(10,26,50,0.65); color: #eaf4ff;
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; font-size: 0.96rem; font-style: normal;
                cursor: pointer; transition: all 0.25s ease; text-align: left; letter-spacing: 0.02em;
                position: relative; overflow: hidden;
            }
            .nav-btn::before {
                content: ''; position: absolute; left: 0; top: 0; bottom: 0;
                width: 4px; background: linear-gradient(180deg, #7ca9ff, #4a7dcc);
                transform: scaleY(0); transition: transform 0.25s ease;
            }
            .nav-btn:hover { border-color: #7ca9ff; color: #ffffff; padding-left: 24px; background: rgba(124,169,255,0.12); }
            .nav-btn:hover::before { transform: scaleY(1); }

            /* daily note in sidebar */
            .daily-note {
                margin-top: auto; padding: 10px 12px;
                border: 2px solid #2a3d54; border-radius: 8px;
                background: rgba(42,61,84,0.3);
            }
            .daily-note-label {
                font-size: 0.6rem; letter-spacing: 0.18em; text-transform: uppercase;
                color: #ffffff; opacity: 0.7; margin-bottom: 6px; display: block;
            }
            .daily-note-text {
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; font-size: 0.85rem;
                color: #ffffff; line-height: 1.4;
            }

            /* ג”€ג”€ MAIN ג”€ג”€ */
            .main {
                flex: 1; display: flex; align-items: center; justify-content: center;
                padding: 60px 64px;
                padding-bottom: max(60px, env(safe-area-inset-bottom));
                padding-right: max(64px, env(safe-area-inset-right));
                padding-left: max(64px, env(safe-area-inset-left));
                min-height: 100vh;
            }
            .hero { max-width: 600px; width: 100%; }
            .hero-eyebrow {
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif; font-size: 1.35rem;
                color: #ffffff; letter-spacing: 0.08em; margin-bottom: 14px;
                opacity: 0; animation: slideUp 0.8s ease 0.2s forwards;
            }
            .hero-title {
                font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                font-size: clamp(3rem, 5.5vw, 6rem); font-weight: 900;
                line-height: 1; letter-spacing: -0.02em; color: #f5f0eb;
                opacity: 0; animation: slideUp 0.9s ease 0.4s forwards;
            }
            .hero-title em {
                font-style: italic; color: #c8ddff; display: block;
                font-size: 0.62em; font-weight: 400; letter-spacing: 0.04em;
                text-shadow: none;
            }
            .title-underline {
                width: 0; height: 2px;
                background: linear-gradient(90deg, #7ca9ff, #4a7dcc);
                margin-bottom: 28px; animation: expandLine 1s ease 1s forwards; border-radius: 2px;
            }
            @keyframes expandLine { to { width: 180px; } }
            .hero-body {
                font-size: 1.2rem; line-height: 1.9; color: #c2d7ff;
                font-weight: 300; max-width: 520px;
                opacity: 0; animation: slideUp 0.9s ease 0.7s forwards;
            }
            .hero-body strong { color: #ffffff; font-weight: 600; }
            .badge {
                display: inline-flex; align-items: center; gap: 8px; margin-top: 26px;
                padding: 10px 18px; border: 2px solid #ffffff; border-radius: 8px;
                background: rgba(255,255,255,0.1); color: #ffffff;
                font-size: 0.85rem; letter-spacing: 0.14em; text-transform: uppercase;
                opacity: 0; animation: slideUp 0.9s ease 1s forwards;
            }

            /* floating hearts desktop only */
            .floating-hearts { display: none; }

            @keyframes slideUp {
                from { opacity: 0; transform: translateY(20px); }
                to { opacity: 1; transform: translateY(0); }
            }

            /* ג”€ג”€ MOBILE ג”€ג”€ */
            @media (max-width: 768px) {
                body { cursor: auto; }
                .layout { flex-direction: column; }
                .sidebar {
                    width: 100%; height: auto; position: relative;
                    border-right: none; border-bottom: 2px solid rgba(255,255,255,0.12);
                    padding: max(16px, env(safe-area-inset-top)) max(16px, env(safe-area-inset-right)) 14px max(16px, env(safe-area-inset-left));
                }
                .logo-wrap { flex-direction: row; gap: 12px; margin-bottom: 12px; align-items: center; }
                .logo-frame { width: 52px; height: 52px; flex-shrink: 0; }
                .logo-name { margin-top: 0; font-size: 1rem; text-align: left; }
                .divider { display: none; }
                .nav-label { display: none; }
                .nav-grid { display: none; }
                .daily-note { display: none; }
                .main {
                    padding: 28px max(18px, env(safe-area-inset-right)) max(48px, env(safe-area-inset-bottom)) max(18px, env(safe-area-inset-left));
                    min-height: auto;
                }
                .hero-title { font-size: clamp(2.4rem, 10vw, 3.5rem); }
                .hero-body { font-size: 1rem; }
                .badge { font-size: 0.75rem; padding: 8px 14px; }
                .floating-hearts { display: none; }
                .title-underline { margin-bottom: 20px; }
            }
        </style>
    </head>
    <body>
        <div class="bg-canvas"></div>
        <div id="petals"></div>

        <div class="layout">
            <aside class="sidebar">
                <div class="logo-wrap">
                    <div class="logo-frame logo-click" id="logo-click">
                        <img src="/yasmin-Photoroom.png" alt="Yasmin">
                    </div>
                    <div class="logo-name">Yasmin</div>
                </div>
                <div class="divider"></div>
                <div class="nav-label">Chickenron!</div>
                <div class="nav-grid">
                    <div class="meter">
                        <div class="meter-title">app complete</div>
                        <div class="meter-track"><div class="meter-fill" id="appProgressFill"></div></div>
                        <div class="meter-details">
                            <span class="meter-percent" id="appProgressPercent">0%</span>
                            <span class="meter-count" id="appProgressCount">0 / 5</span>
                        </div>
                    </div>
                </div>
            </aside>

            <main class="main">
                <div class="hero">
                    <div class="hero-eyebrow">&#8212; Where's my vape? &#8212;</div>
                    <h1 class="hero-title">
                        THE FUCKING NUMBER 1 APP OF THE YEAR, ABSOLUTELY FIRE!
                        <em>MADE BY ME!</em>
                    </h1>
                    <div class="title-underline"></div>
                    <p class="hero-body">
                        I AM TESTING BULLSHIT AND PUTTING IT ONLINE BECAUSE YOU DONT FIND THIS ROMANTIC!
                    </p>
                    <div class="badge" onclick="location.href='/relationship'" style="cursor: pointer;">&#10022; &nbsp; Enter Our Love Story &nbsp; &#10022;</div>
                </div>
            </main>
        </div>

        <div class="floating-hearts">
            <span class="fheart">&#9829;</span>
            <span class="fheart">&#9825;</span>
            <span class="fheart">&#9829;</span>
            <span class="fheart">&#9825;</span>
        </div>

        <script>
            // Register service worker
            if ('serviceWorker' in navigator) {
                navigator.serviceWorker.register('/sw.js')
                    .then(reg => console.log('Service Worker registered'))
                    .catch(err => console.log('Service Worker registration failed:', err));
            }

            document.getElementById("logo-click").addEventListener("click", () => {
                if (localStorage.getItem("secret_unlocked") === "true") {
                    window.location.href = "/secret.html";
                }
            });

            const appProgress = { completed: 3, total: 20 };
            const appPercent = Math.round((appProgress.completed / appProgress.total) * 100);
            document.getElementById('appProgressFill').style.width = appPercent + '%';
            document.getElementById('appProgressPercent').textContent = appPercent + '%';
            document.getElementById('appProgressCount').textContent = appProgress.completed + ' / ' + appProgress.total;

            const today = new Date();
            const idx = (today.getFullYear() * 366 + today.getMonth() * 31 + today.getDate()) % dailyNotes.length;
            document.getElementById('dailyNote').textContent = dailyNotes[idx];

            // Petals
            const pc = document.getElementById('petals');
            const petalChars = ['\u2665','\u2661','\u2764','\u273F'];
            const petalColors = ['#ffffff','#7ca9ff','#ffffff','#4a7dcc'];
            function spawnPetal() {
                const p = document.createElement('div');
                p.className = 'petal';
                p.textContent = petalChars[Math.floor(Math.random() * petalChars.length)];
                p.style.left = Math.random() * 100 + 'vw';
                p.style.fontSize = (0.8 + Math.random() * 1.2) + 'rem';
                p.style.animationDuration = (6 + Math.random() * 8) + 's';
                p.style.animationDelay = (Math.random() * 3) + 's';
                p.style.color = petalColors[Math.floor(Math.random() * petalColors.length)];
                pc.appendChild(p);
                setTimeout(() => p.remove(), 15000);
            }
            setInterval(spawnPetal, 900);
            for (let i = 0; i < 8; i++) setTimeout(spawnPetal, i * 350);
        </script>
    </body>
    </html>
    """, "text/html", System.Text.Encoding.UTF8);
});

// ========== PAGE ROUTES ==========
app.MapRelationshipPage();

// Run on port from environment or default (Railway uses PORT)
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Run($"http://0.0.0.0:{port}");
