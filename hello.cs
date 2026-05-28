public static class HelloPage
{
    public static void MapHelloPage(this WebApplication app)
    {
        app.MapGet("/hello", () =>
        {
            return Results.Content("""
            <html>
            <head>
            <meta charset="UTF-8">
            <meta name="viewport" content="width=device-width, initial-scale=1.0">
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
                        display: flex; align-items: center; justify-content: center; min-height: 100vh;
                    }
                    .petal { position: fixed; pointer-events: none; animation: petalFall linear infinite; z-index: 0; opacity: 0.45; }
                    @keyframes petalFall {
                        0% { transform: translateY(-40px) rotate(0deg); opacity: 0.5; }
                        100% { transform: translateY(105vh) rotate(540deg) translateX(25px); opacity: 0; }
                    }
                    .card {
                        width: min(620px, 90%);
                        padding: 64px 52px 52px;
                        border-radius: 4px;
                        background: rgba(22,5,14,0.88);
                        border: 1px solid rgba(212,168,67,0.2);
                        box-shadow: 0 50px 120px rgba(0,0,0,0.6), inset 0 1px 0 rgba(212,168,67,0.12);
                        backdrop-filter: blur(28px);
                        text-align: center; position: relative; overflow: hidden; z-index: 1;
                        animation: cardIn 0.8s ease forwards;
                    }
                    @keyframes cardIn {
                        from { opacity: 0; transform: translateY(40px) scale(0.97); }
                        to { opacity: 1; transform: translateY(0) scale(1); }
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
                        margin-bottom: 16px;
                        opacity: 0; animation: slideUp 0.6s ease 0.2s forwards;
                    }
                    h1 {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: clamp(3rem, 8vw, 5.5rem);
                        font-weight: 900; font-style: italic;
                        color: var(--cream); letter-spacing: -0.03em;
                        line-height: 1;
                        text-shadow: 0 0 60px rgba(255,112,150,0.4);
                        animation: glow 3s ease-in-out infinite, slideUp 0.7s ease 0.35s both;
                    }
                    @keyframes glow {
                        0%, 100% { text-shadow: 0 0 40px rgba(255,112,150,0.3); }
                        50% { text-shadow: 0 0 80px rgba(255,112,150,0.7), 0 0 120px rgba(232,64,106,0.3); }
                    }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 20px auto; animation: expandLine 1s ease 0.9s forwards;
                    }
                    @keyframes expandLine { to { width: 120px; } }

                    .love-lines {
                        margin: 8px 0 24px;
                        opacity: 0; animation: slideUp 0.7s ease 0.6s forwards;
                    }
                    .love-line {
                        font-size: 1.3rem;
                        line-height: 2.1;
                        color: rgba(255,220,230,0.88);
                        font-weight: 300;
                    }
                    .love-line strong {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-style: italic;
                        color: var(--rose-light);
                        font-weight: 400;
                    }

                    .hearts-row {
                        display: flex; gap: 12px; justify-content: center;
                        margin: 24px 0;
                        opacity: 0; animation: slideUp 0.7s ease 0.8s forwards;
                    }
                    .heart {
                        font-size: 1.6rem;
                        animation: floatHeart 2.5s ease-in-out infinite;
                        filter: drop-shadow(0 0 8px rgba(232,64,106,0.5));
                    }
                    .heart:nth-child(2) { animation-delay: 0.3s; font-size: 1.1rem; }
                    .heart:nth-child(3) { animation-delay: 0.6s; font-size: 2rem; }
                    .heart:nth-child(4) { animation-delay: 0.9s; font-size: 1.1rem; }
                    .heart:nth-child(5) { animation-delay: 1.2s; font-size: 1.6rem; }
                    @keyframes floatHeart {
                        0%, 100% { transform: translateY(0); }
                        50% { transform: translateY(-12px); }
                    }

                    .back-btn {
                        margin-top: 28px; padding: 14px 36px;
                        border-radius: 2px; border: 1px solid rgba(212,168,67,0.3);
                        background: transparent; color: var(--gold-light);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1rem; font-style: italic; letter-spacing: 0.1em;
                        cursor: pointer; transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.7s ease 1.1s forwards;
                    }
                    .back-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        background: rgba(212,168,67,0.08); transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    @media(max-width:480px){
                        .card{padding:36px 20px 32px;}
                        h1{font-size:clamp(2.4rem,10vw,3.5rem);}
                        .love-line{font-size:1.1rem;}
                    }
                    button{-webkit-tap-highlight-color:transparent;}

                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="card">
                    <div class="eyebrow">ג€” a whole website, just for you ג€”</div>
                    <h1>Helloww</h1>
                    <div class="gold-line"></div>
                    <div class="love-lines">
                        <p class="love-line">I made a whole website</p>
                        <p class="love-line">just to say <strong>I love you.</strong></p>
                        <p class="love-line">btw you're pretty cute.</p>
                        <p class="love-line"><strong>I LOVE YOUUU ג™¡</strong></p>
                    </div>
                    <div class="hearts-row">
                        <span class="heart">ג™¥</span>
                        <span class="heart">ג™¡</span>
                        <span class="heart">ג™¥</span>
                        <span class="heart">ג™¡</span>
                        <span class="heart">ג™¥</span>
                    </div>
                    <button class="back-btn" onclick="location.href='/Yas'">ג† return home</button>
                </div>
                <script>
                    const pc = document.getElementById('petals');
                    const ps = ['נ¸','ג₪ן¸','נ¹'];
                    function sp() {
                        const p = document.createElement('div'); p.className = 'petal';
                        p.textContent = ps[Math.floor(Math.random() * ps.length)];
                        p.style.left = Math.random() * 100 + 'vw';
                        p.style.fontSize = (0.7 + Math.random() * 1.2) + 'rem';
                        p.style.animationDuration = (6 + Math.random() * 9) + 's';
                        p.style.animationDelay = (Math.random() * 3) + 's';
                        pc.appendChild(p); setTimeout(() => p.remove(), 16000);
                    }
                    setInterval(sp, 900);
                    for (let i = 0; i < 8; i++) setTimeout(sp, i * 300);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}
