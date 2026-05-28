public static class BlehhPage
{
    public static void MapBlehhPage(this WebApplication app)
    {
        app.MapGet("/blehhh", () =>
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
                    .petal { position: fixed; pointer-events: none; animation: petalFall linear infinite; z-index: 0; opacity: 0.4; }
                    @keyframes petalFall {
                        0% { transform: translateY(-40px) rotate(0deg); opacity: 0.5; }
                        100% { transform: translateY(105vh) rotate(540deg) translateX(25px); opacity: 0; }
                    }
                    .card {
                        width: min(540px, 90%);
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

                    @keyframes rumble {
                        0%   { transform: translate(0,0) rotate(0deg); }
                        10%  { transform: translate(-10px,-8px) rotate(-1.5deg); }
                        20%  { transform: translate(10px,8px) rotate(1.5deg); }
                        30%  { transform: translate(-12px,5px) rotate(0.8deg); }
                        40%  { transform: translate(12px,-5px) rotate(-0.8deg); }
                        50%  { transform: translate(-8px,10px) rotate(1.2deg); }
                        60%  { transform: translate(8px,-10px) rotate(-1.2deg); }
                        70%  { transform: translate(-10px,5px) rotate(0.6deg); }
                        80%  { transform: translate(10px,-5px) rotate(-0.6deg); }
                        90%  { transform: translate(-5px,8px) rotate(0deg); }
                        100% { transform: translate(0,0) rotate(0deg); }
                    }
                    .rumbling { animation: rumble 0.5s ease !important; }

                    .blehhh-btn {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: clamp(3rem, 8vw, 5rem);
                        font-style: italic; font-weight: 900;
                        padding: 24px 60px;
                        border-radius: 4px;
                        border: 1px solid rgba(212,168,67,0.3);
                        background: rgba(255,255,255,0.025);
                        color: var(--soft-pink);
                        cursor: pointer;
                        letter-spacing: -0.02em;
                        transition: all 0.3s ease;
                        position: relative; overflow: hidden;
                        opacity: 0; animation: slideUp 0.6s ease 0.5s forwards;
                    }
                    .blehhh-btn::before {
                        content: ''; position: absolute; inset: 0;
                        background: radial-gradient(circle at 50% 50%, rgba(232,64,106,0.12), transparent 70%);
                        opacity: 0; transition: opacity 0.3s;
                    }
                    .blehhh-btn:hover {
                        transform: scale(1.05);
                        border-color: var(--rose-light);
                        color: var(--cream);
                        box-shadow: 0 20px 60px rgba(232,64,106,0.2), 0 0 40px rgba(232,64,106,0.1);
                    }
                    .blehhh-btn:hover::before { opacity: 1; }

                    .back-btn {
                        margin-top: 32px; display: inline-block;
                        padding: 12px 32px; border-radius: 2px;
                        border: 1px solid rgba(212,168,67,0.2);
                        background: transparent; color: rgba(212,168,67,0.6);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 0.95rem; font-style: italic; letter-spacing: 0.1em;
                        cursor: pointer; transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.6s ease 0.8s forwards;
                    }
                    .back-btn:hover {
                        color: var(--cream); border-color: var(--gold);
                        background: rgba(212,168,67,0.06); transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                    @media(max-width:480px){
                        .card{padding:36px 20px 32px;}
                        .blehhh-btn{font-size:clamp(2.4rem,10vw,3.8rem);padding:18px 40px;}
                    }
                    button{-webkit-tap-highlight-color:transparent;}

                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="card" id="main-card">
                    <div class="eyebrow">ג€” BLEHHHHH ג€”</div>
                    <br>
                    <button class="blehhh-btn" id="blehhh-btn">blehhh</button>
                    <br>
                    <button class="back-btn" onclick="location.href='/Yas'">ג† return home</button>
                </div>
                <script>
                    const btn = document.getElementById('blehhh-btn');
                    const body = document.body;

                    btn.addEventListener('click', () => {
                        body.classList.remove('rumbling');
                        void body.offsetWidth;
                        body.classList.add('rumbling');
                        if (navigator.vibrate) navigator.vibrate([120, 60, 120]);
                        body.addEventListener('animationend', () => body.classList.remove('rumbling'), { once: true });
                    });

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
