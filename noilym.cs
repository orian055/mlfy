public static class NoIlymPage
{
    public static void MapNoIlymPage(this WebApplication app)
    {
        app.MapGet("/noilym", () =>
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
                        width: min(600px, 90%);
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
                        font-size: 1.3rem; color: var(--gold-light); margin-bottom: 12px;
                        opacity: 0; animation: slideUp 0.6s ease 0.2s forwards;
                    }
                    h1 {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: clamp(2.4rem, 6vw, 3.8rem); font-weight: 700;
                        color: var(--cream); letter-spacing: -0.02em;
                        opacity: 0; animation: slideUp 0.6s ease 0.35s forwards;
                    }
                    h1 em { font-style: italic; color: var(--rose-light); }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 20px auto; animation: expandLine 1s ease 0.8s forwards;
                    }
                    @keyframes expandLine { to { width: 100px; } }

                    .btn-group {
                        display: flex; gap: 14px; justify-content: center;
                        flex-wrap: wrap; margin-top: 36px;
                        opacity: 0; animation: slideUp 0.6s ease 0.65s forwards;
                    }
                    .choice-btn {
                        padding: 18px 40px;
                        border-radius: 4px;
                        border: 1px solid rgba(212,168,67,0.25);
                        background: rgba(255,255,255,0.025);
                        color: var(--soft-pink);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1.2rem; font-style: italic;
                        cursor: pointer; transition: all 0.3s ease;
                        position: relative; overflow: hidden;
                    }
                    .choice-btn::before {
                        content: ''; position: absolute; inset: 0;
                        background: linear-gradient(135deg, rgba(212,168,67,0.1), rgba(232,64,106,0.08));
                        opacity: 0; transition: opacity 0.3s;
                    }
                    .choice-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        transform: translateY(-4px);
                        box-shadow: 0 20px 50px rgba(0,0,0,0.4), 0 0 30px rgba(212,168,67,0.1);
                    }
                    .choice-btn:hover::before { opacity: 1; }
                    .choice-btn.disabled {
                        opacity: 0.4; cursor: not-allowed; filter: blur(0.5px);
                    }
                    .choice-btn.disabled:hover {
                        transform: none; box-shadow: none; border-color: rgba(212,168,67,0.15);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    @media(max-width:480px){
                        .card{padding:36px 20px 32px;}
                        .btn-group{flex-direction:column;align-items:center;}
                        .choice-btn{width:100%;max-width:280px;}
                    }
                    button{-webkit-tap-highlight-color:transparent;}

                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="card">
                    <div class="eyebrow">ג€” settle this once and for all ג€”</div>
                    <h1>Who loves <em>more?</em></h1>
                    <div class="gold-line"></div>
                    <div class="btn-group">
                        <button class="choice-btn" onclick="location.href='/Yas'">Orian ג™¡</button>
                        <button class="choice-btn disabled" title="not an option">Yasmin</button>
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
