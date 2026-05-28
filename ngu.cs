public static class NguPage
{
    public static void MapNguPage(this WebApplication app)
    {
        app.MapGet("/ngu", () =>
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
                        width: min(680px, 90%);
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
                    #challenge-text {
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: clamp(2rem, 5vw, 3.4rem);
                        font-weight: 700; font-style: italic;
                        color: var(--cream); letter-spacing: -0.02em;
                        line-height: 1.15; margin-bottom: 0;
                        transition: font-size 0.4s ease, color 0.4s ease, text-shadow 0.4s ease;
                        opacity: 0; animation: slideUp 0.6s ease 0.35s forwards;
                    }
                    .gold-line {
                        width: 0; height: 1px;
                        background: linear-gradient(90deg, transparent, var(--gold), transparent);
                        margin: 20px auto; animation: expandLine 1s ease 0.8s forwards;
                    }
                    @keyframes expandLine { to { width: 100px; } }

                    .btn-wrap {
                        margin-top: 36px;
                        opacity: 0; animation: slideUp 0.6s ease 0.65s forwards;
                    }
                    #challenge-btn {
                        padding: 18px 52px;
                        border-radius: 4px;
                        border: 1px solid rgba(212,168,67,0.3);
                        background: rgba(255,255,255,0.03);
                        color: var(--soft-pink);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 1.3rem; font-style: italic;
                        cursor: pointer; transition: all 0.3s ease;
                        position: relative; overflow: hidden;
                    }
                    #challenge-btn::before {
                        content: ''; position: absolute; inset: 0;
                        background: linear-gradient(135deg, rgba(212,168,67,0.1), rgba(232,64,106,0.08));
                        opacity: 0; transition: opacity 0.3s;
                    }
                    #challenge-btn:hover {
                        border-color: var(--gold); color: var(--cream);
                        transform: translateY(-3px);
                        box-shadow: 0 20px 50px rgba(0,0,0,0.4);
                    }
                    #challenge-btn:hover::before { opacity: 1; }

                    .back-btn {
                        margin-top: 24px; display: block;
                        padding: 12px 32px; border-radius: 2px;
                        border: 1px solid rgba(212,168,67,0.2);
                        background: transparent; color: rgba(212,168,67,0.6);
                        font-family: 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
                        font-size: 0.95rem; font-style: italic; letter-spacing: 0.1em;
                        cursor: pointer; transition: all 0.3s ease;
                        opacity: 0; animation: slideUp 0.6s ease 0.9s forwards;
                        margin-left: auto; margin-right: auto;
                    }
                    .back-btn:hover {
                        color: var(--cream); border-color: var(--gold);
                        background: rgba(212,168,67,0.06); transform: translateY(-2px);
                    }
                    @keyframes slideUp {
                        from { opacity: 0; transform: translateY(20px); }
                        to { opacity: 1; transform: translateY(0); }
                    }
                        @media (max-width: 600px) {
                       body {
                      padding: 12px;
                           align-items: flex-start; /* prevents vertical squeeze */
                        }

                            .card {
                         width: 100%;
                          padding: 32px 18px 28px;
                          border-radius: 6px;
                          }

                          .eyebrow {
                          font-size: 1rem;
                          }

                              #challenge-text {
                             font-size: 1.8rem !important;
                         line-height: 1.25;
                       }

                          .gold-line {
                         margin: 16px auto;
                          }

                          .btn-wrap {
                          margin-top: 24px;
                          }

                          #challenge-btn {
                          width: 100%;
                          padding: 16px;
                              font-size: 1.1rem;
                          }

                              .back-btn {
                             width: 100%;
                          padding: 14px;
                        font-size: 0.9rem;
                                 }
                            }

                  </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="card">
                    <div class="eyebrow">— a test of character —</div>
                    <p id="challenge-text">never back down, never what?</p>
                    <div class="gold-line"></div>
                    <div class="btn-wrap">
                        <button id="challenge-btn">never give up</button>
                    </div>
                    <button class="back-btn" onclick="location.href='/Yas'">← return home</button>
                </div>
                <script>
                    const challengeText = document.getElementById('challenge-text');
                    const challengeBtn = document.getElementById('challenge-btn');
                    let clickCount = 0;

                    challengeBtn.addEventListener('click', () => {
                        clickCount++;
                        if (clickCount === 1) {
                            challengeText.textContent = 'never back down, never what!!';
                            challengeText.style.fontSize = 'clamp(2.2rem, 5.5vw, 3.8rem)';
                        } else if (clickCount === 2) {
                            challengeText.textContent = 'NEVER BACK DOWN, NEVER WHAT!!!';
                            challengeText.style.fontSize = 'clamp(2.4rem, 6vw, 4.2rem)';
                            challengeText.style.color = 'var(--rose-light)';
                            challengeText.style.textShadow = '0 0 40px rgba(255,112,150,0.5)';
                        } else if (clickCount === 3) {
                            challengeText.textContent = 'SO WHO LOVES MORE?!';
                            challengeText.style.fontSize = 'clamp(2.6rem, 6.5vw, 4.6rem)';
                            challengeText.style.color = 'var(--gold-light)';
                            challengeText.style.textShadow = '0 0 50px rgba(212,168,67,0.5)';
                            challengeBtn.textContent = 'yasmin ♡';
                        } else {
                            alert('ill consider this as an option 😏');
                            location.href = '/Yas';
                        }
                    });

                    const pc = document.getElementById('petals');
                    const ps = ['🌸','♡','❤️','✿','❧'];
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
