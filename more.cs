public static class MorePage
{
    public static void MapMorePage(this WebApplication app)
    {
        app.MapGet("/more", () =>
        {
            return Results.Content("""
            <html>
            <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0, viewport-fit=cover, user-scalable=no, maximum-scale=1">
            <meta name="theme-color" content="#ffffff">
            <meta name="apple-mobile-web-app-capable" content="yes">
            <meta name="apple-mobile-web-app-status-bar-style" content="black-translucent">
            <meta name="apple-mobile-web-app-title" content="Love Portal">
            <meta name="format-detection" content="telephone=no">
                <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:ital,wght@0,400;0,700;0,900;1,400;1,700&family=Cormorant+Garamond:ital,wght@0,300;0,400;0,600;1,300;1,400&family=Dancing+Script:wght@600;700&display=swap" rel="stylesheet">
                <style>
                    :root {
                        --rose: #ffffff; --rose-light: #ffffff;
                        --gold: #d4a843; --gold-light: #f0c96a;
                        --cream: #fff5f7; --deep: #1a0610; --soft-pink: #ffffff;
                    }
                    * { box-sizing: border-box; margin: 0; padding: 0; }
                    body {
                        min-height: 100vh;
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        background:
                            radial-gradient(ellipse at 15% 25%, rgba(158,26,58,0.28) 0%, transparent 50%),
                            radial-gradient(ellipse at 85% 75%, rgba(74,14,32,0.35) 0%, transparent 45%),
                            linear-gradient(160deg, #1a0610 0%, #2d0a1a 40%, #1a0610 100%);
                        color: var(--cream); overflow-x: hidden;
                    }
                    .petal { position: fixed; pointer-events: none; animation: petalFall linear infinite; z-index: 0; opacity: 0.45; }
                    @keyframes petalFall {
                        0% { transform: translateY(-40px) rotate(0deg); opacity: 0.5; }
                        100% { transform: translateY(105vh) rotate(540deg) translateX(25px); opacity: 0; }
                    }
                    .page-wrap {
                        min-height: 100vh;
                        display: flex; align-items: center; justify-content: center;
                        padding: 48px 24px; position: relative; z-index: 1;
                    }
                    .card {
                        width: min(700px, 100%);
                        padding: 60px 52px 48px;
                        border-radius: 4px;
                        background: rgba(22,5,14,0.88);
                        border: 1px solid rgba(212,168,67,0.2);
                        box-shadow: 0 50px 120px rgba(0,0,0,0.6), inset 0 1px 0 rgba(212,168,67,0.12);
                        backdrop-filter: blur(28px);
                        text-align: center; position: relative; overflow: hidden;
                        animation: cardIn 0.8s ease forwards;
                    }
                    @keyframes cardIn {
                        from { opacity: 0; transform: translateY(40px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    .card::before {
                        content: ''; position: absolute; top: 0; left: 0; right: 0; height: 2px;
                        background: linear-gradient(90deg, transparent, var(--gold), var(--rose-light), var(--gold), transparent);
                        background-size: 200% 100%; animation: shimmer 3s linear infinite;
                    }
                    @keyframes shimmer { from { background-position: 200% 0; } to { background-position: -200% 0; } }

                    .eyebrow {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1.3rem; color: var(--gold-light);
                        letter-spacing: 0.08em; margin-bottom: 10px;
                        opacity: 0; animation: slideUp 0.7s ease 0.2s forwards;
                    }
                    h1 {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: clamp(2.4rem, 5vw, 3.6rem);
                        font-weight: 700; color: var(--cream);
                        letter-spacing: -0.02em; line-height: 1.1;
                        opacity: 0; animation: slideUp 0.7s ease 0.35s forwards;
                    }
                    h1 em { font-style: italic; color: var(--rose-light); }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 18px auto; animation: expandLine 1s ease 0.8s forwards;
                    }
                    @keyframes expandLine { to { width: 100px; } }
                    .sub {
                        font-size: 1.05rem; color: rgba(249,196,212,0.7);
                        font-style: italic; font-weight: 300; margin-bottom: 36px;
                        opacity: 0; animation: slideUp 0.7s ease 0.5s forwards;
                    }

                    .btn-grid {
                        display: grid;
                        grid-template-columns: repeat(2, 1fr);
                        gap: 12px; margin-bottom: 28px;
                        opacity: 0; animation: slideUp 0.7s ease 0.65s forwards;
                    }
                    .action-btn {
                        padding: 20px 16px;
                        border-radius: 4px;
                        border: 1px solid rgba(212,168,67,0.15);
                        background: rgba(255,255,255,0.025);
                        color: var(--soft-pink);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1.05rem; font-style: italic;
                        letter-spacing: 0.03em;
                        cursor: pointer;
                        transition: all 0.3s ease;
                        position: relative; overflow: hidden;
                    }
                    .action-btn::before {
                        content: '';
                        position: absolute; inset: 0;
                        background: linear-gradient(135deg, rgba(232,64,106,0.08), transparent);
                        opacity: 0; transition: opacity 0.3s;
                    }
                    .action-btn::after {
                        content: '';
                        position: absolute; bottom: 0; left: 0; right: 0; height: 2px;
                        background: linear-gradient(90deg, var(--rose), var(--gold));
                        transform: scaleX(0); transition: transform 0.3s ease;
                    }
                    .action-btn:hover {
                        border-color: rgba(212,168,67,0.4);
                        color: var(--cream);
                        transform: translateY(-3px);
                        box-shadow: 0 15px 35px rgba(0,0,0,0.3);
                    }
                    .action-btn:hover::before { opacity: 1; }
                    .action-btn:hover::after { transform: scaleX(1); }

                    .back-btn {
                        padding: 14px 36px; border-radius: 2px;
                        border: 1px solid rgba(212,168,67,0.3);
                        background: transparent; color: var(--gold-light);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1rem; font-style: italic; letter-spacing: 0.1em;
                        cursor: pointer; transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.7s ease 1s forwards;
                    }
                    .back-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        background: rgba(212,168,67,0.08); transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    @media (max-width: 600px) {
                    .page-wrap {
                    padding: 24px 12px;
                    }

                    .card {
                    padding: 32px 20px 28px;
                    border-radius: 8px;
                      }

                       h1 {
                    font-size: 2rem;
                    }

                      .sub {
                     font-size: 0.95rem;
                     margin-bottom: 24px;
                        }

                     .btn-grid {
                       grid-template-columns: 1fr; /* stack buttons */
                     gap: 10px;
                     }

                     .action-btn {
                     padding: 16px 12px;
                     font-size: 0.95rem;
                         }

                      .back-btn {
                      width: 100%;
                          padding: 14px;
                      }
                        }

                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="page-wrap">
                    <div class="card">
                        <div class="eyebrow">ג€” the eternal debate ג€”</div>
                        <h1>I Love You <em>More!</em></h1>
                        <div class="gold-line"></div>
                        <p class="sub">What do you have to say about that?</p>

                        <div class="btn-grid">
                            <button class="action-btn" onclick="location.href='/noilym'">No, I love YOU more!</button>
                            <button class="action-btn" onclick="location.href='/ngu'">I give up...</button>
                            <button class="action-btn" onclick="location.href='/blehhh'">Blehhh נ˜₪</button>
                            <button class="action-btn" onclick="location.href='/hello'">Hello ג™¡</button>
                        </div>

                        <button class="back-btn" onclick="location.href='/Yas'">ג† return home</button>
                    </div>
                </div>
                <script>
                    const pc = document.getElementById('petals');
                    const ps = ['נ¸','ג₪ן¸'];
                    function sp() {
                        const p = document.createElement('div'); p.className = 'petal';
                        p.textContent = ps[Math.floor(Math.random() * ps.length)];
                        p.style.left = Math.random() * 100 + 'vw';
                        p.style.fontSize = (0.7 + Math.random() * 1.1) + 'rem';
                        p.style.animationDuration = (7 + Math.random() * 9) + 's';
                        p.style.animationDelay = (Math.random() * 3) + 's';
                        pc.appendChild(p); setTimeout(() => p.remove(), 16000);
                    }
                    setInterval(sp, 1000);
                    for (let i = 0; i < 6; i++) setTimeout(sp, i * 400);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}
