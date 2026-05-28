public static class RelationshipPage
{
    public static void MapRelationshipPage(this WebApplication app)
    {
        app.MapGet("/relationship", () =>
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
                        --rose:#ffffff; --rose-light:#c8e0ff;
                        --gold:#4a7dcc; --gold-light:#7ca9ff;
                        --cream:#e8f2ff; --deep:#08101e; --soft-pink:#ffffff;
                    }
                    *{box-sizing:border-box;margin:0;padding:0;}
                    body{
                        min-height:100vh;min-height:100dvh;
                        font-family:'Cormorant Garamond',serif;
                        background:
                            radial-gradient(ellipse at 15% 25%,rgba(124,169,255,0.14) 0%,transparent 40%),
                            radial-gradient(ellipse at 85% 75%,rgba(44,86,145,0.26) 0%,transparent 45%),
                            linear-gradient(160deg,#08101e 0%,#121f33 40%,#08101e 100%);
                        color:var(--cream);overflow-x:hidden;
                    }
                    .petal{position:fixed;pointer-events:none;animation:petalFall linear infinite;z-index:0;opacity:0.4;}
                    @keyframes petalFall{0%{transform:translateY(-40px) rotate(0deg);opacity:0.5;}100%{transform:translateY(105vh) rotate(540deg) translateX(25px);opacity:0;}}
                    .page-wrap{
                        min-height:100vh;min-height:100dvh;
                        display:flex;align-items:flex-start;justify-content:center;
                        gap:28px;padding:28px 16px;position:relative;z-index:1;
                        flex-wrap:wrap;
                    }
                    .card{
                        width:min(620px,100%);
                        padding:48px 44px 40px;border-radius:20px;
                        background:rgba(9,18,35,0.92);
                        border:1px solid rgba(124,169,255,0.12);
                        box-shadow:0 40px 100px rgba(0,0,0,0.45),inset 0 1px 0 rgba(124,169,255,0.08);
                        backdrop-filter:blur(28px);text-align:center;position:relative;overflow:hidden;
                        animation:cardIn 0.8s ease forwards;
                    }
                    .meter{
                        width:min(760px,100%);display:flex;flex-direction:column;align-items:flex-start;gap:18px;
                        padding:24px 18px;border-radius:22px;background:rgba(9,18,35,0.92);
                        border:1px solid rgba(124,169,255,0.18);box-shadow:0 25px 70px rgba(5,11,24,0.55);
                    }
                    .meter-title{
                        font-family:'Cormorant Garamond',serif;font-size:0.78rem;letter-spacing:0.18em;text-transform:uppercase;
                        color:rgba(124,169,255,0.92);margin-bottom:4px;
                    }
                    .meter-body{
                        width:100%;display:flex;align-items:flex-start;gap:18px;
                    }
                    .meter-track{
                        position:relative;width:10px;min-height:320px;background:rgba(255,255,255,0.08);border-radius:999px;
                        flex-shrink:0;
                    }
                    .meter-fill{
                        position:absolute;bottom:0;left:0;right:0;
                        background:linear-gradient(180deg,rgba(124,169,255,0.95),rgba(255,255,255,0.9));
                        border-radius:999px 999px 0 0;height:0%;transition:height 0.45s ease;
                    }
                    .meter-content{display:flex;flex-direction:column;justify-content:space-between;min-height:320px;width:100%;}
                    .meter-summary{
                        width:100%;display:flex;justify-content:space-between;gap:14px;flex-wrap:wrap;
                        padding:10px 14px;border-radius:16px;background:rgba(255,255,255,0.05);border:1px solid rgba(124,169,255,0.12);
                    }
                    .meter-count{font-size:0.92rem;font-weight:700;color:#ffffff;}
                    .meter-next{font-size:0.9rem;color:rgba(124,169,255,0.92);letter-spacing:0.02em;}
                    .meter-item{
                        display:flex;align-items:flex-start;gap:10px;position:relative;padding-left:4px;
                    }
                    .meter-item.next .meter-item-title{color:#a3c4ff;}
                    .meter-item.next .meter-item-year{color:#d3e3ff;}
                    .meter-item.next::before{
                        box-shadow:0 0 18px rgba(124,169,255,0.18);
                        border-color:rgba(184,210,255,0.7);
                    }
                    .meter-item::before{
                        content:'';width:14px;height:14px;border-radius:50%;background:rgba(255,255,255,0.12);
                        border:2px solid rgba(124,169,255,0.4);flex-shrink:0;transform:translateY(4px);
                    }
                    .meter-item.active::before{
                        background:var(--gold-light);border-color:var(--gold);box-shadow:0 0 20px rgba(124,169,255,0.35);
                    }
                    .meter-item .meter-item-title{font-size:0.85rem;color:rgba(255,255,255,0.95);line-height:1.25;}
                    .meter-item .meter-item-year{font-size:0.7rem;color:rgba(124,169,255,0.75);text-transform:uppercase;letter-spacing:0.16em;margin-top:4px;}
                    .meter-item.active .meter-item-title{color:#ffffff;}
                    .meter-status{
                        font-size:0.88rem;color:rgba(225,235,255,0.9);text-align:center;padding:10px 14px;
                        border:1px solid rgba(124,169,255,0.16);border-radius:999px;background:rgba(10,20,40,0.55);
                    }
                    @keyframes cardIn{from{opacity:0;transform:translateY(40px);}to{opacity:1;transform:translateY(0);}}
                    .card::before{
                        content:'';position:absolute;top:0;left:0;right:0;height:2px;
                        background:linear-gradient(90deg,transparent,var(--gold),var(--rose-light),var(--gold),transparent);
                        background-size:200% 100%;animation:shimmer 3s linear infinite;
                    }
                    @keyframes shimmer{from{background-position:200% 0;}to{background-position:-200% 0;}}
                    .eyebrow{font-family:'Dancing Script',cursive;font-size:1.2rem;color:var(--gold-light);letter-spacing:0.08em;margin-bottom:8px;opacity:0;animation:slideUp 0.7s ease 0.2s forwards;}
                    h1{font-family:'Playfair Display',serif;font-size:clamp(1.8rem,4.5vw,3rem);font-weight:700;color:var(--cream);letter-spacing:-0.02em;line-height:1.1;opacity:0;animation:slideUp 0.7s ease 0.35s forwards;}
                    h1 em{font-style:italic;color:var(--rose-light);}
                    .gold-line{width:0;height:1px;background:linear-gradient(90deg,transparent,var(--gold),transparent);margin:14px auto;animation:expandLine 1s ease 0.8s forwards;}
                    @keyframes expandLine{to{width:100px;}}
                    .sub{font-size:1rem;color:rgba(200,224,255,0.75);font-style:italic;font-weight:300;margin-bottom:28px;opacity:0;animation:slideUp 0.7s ease 0.5s forwards;}
                    .time-grid{display:grid;grid-template-columns:repeat(2,1fr);gap:12px;margin-bottom:24px;opacity:0;animation:slideUp 0.7s ease 0.65s forwards;}
                    .time-unit{
                        padding:24px 12px 18px;
                        background:rgba(255,255,255,0.03);border:1px solid rgba(124,169,255,0.12);
                        border-radius:4px;position:relative;overflow:hidden;
                        transition:border-color 0.3s,transform 0.3s;
                    }
                    .time-unit:hover{border-color:rgba(124,169,255,0.4);transform:translateY(-2px);}
                    .time-unit::before{content:'';position:absolute;inset:0;background:radial-gradient(circle at 50% 0%,rgba(124,169,255,0.08),transparent 70%);pointer-events:none;}
                    .time-value{
                        font-family:'Playfair Display',serif;font-size:clamp(2rem,6vw,3rem);
                        font-weight:900;color:var(--soft-pink);line-height:1;display:block;
                        text-shadow:0 0 30px rgba(124,169,255,0.25);
                        animation:pulse 2s ease-in-out infinite;
                    }
                    .time-unit:nth-child(2) .time-value{animation-delay:0.5s;}
                    .time-unit:nth-child(3) .time-value{animation-delay:1s;}
                    .time-unit:nth-child(4) .time-value{animation-delay:1.5s;}
                    @keyframes pulse{0%,100%{text-shadow:0 0 30px rgba(124,169,255,0.25);}50%{text-shadow:0 0 50px rgba(124,169,255,0.45);}}
                    .time-label{font-size:0.7rem;color:rgba(124,169,255,0.65);letter-spacing:0.18em;text-transform:uppercase;margin-top:8px;display:block;font-family:'Cormorant Garamond',serif;}
                    .love-note{font-family:'Dancing Script',cursive;font-size:1.3rem;color:var(--gold-light);margin:4px 0 0;opacity:0;animation:slideUp 0.7s ease 0.9s forwards;}
                    .back-btn{
                        margin-top:28px;padding:12px 32px;border-radius:2px;
                        border:1px solid rgba(124,169,255,0.3);background:transparent;color:var(--gold-light);
                        font-family:'Cormorant Garamond',serif;font-size:0.95rem;font-style:italic;letter-spacing:0.1em;
                        cursor:pointer;transition:all 0.3s ease;opacity:0;animation:slideUp 0.7s ease 1.1s forwards;
                        -webkit-tap-highlight-color:transparent;
                    }
                    .back-btn:hover{border-color:var(--gold-light);color:var(--cream);background:rgba(124,169,255,0.08);transform:translateY(-2px);}
                    @keyframes slideUp{from{opacity:0;transform:translateY(20px);}to{opacity:1;transform:translateY(0);}}
                    @media(max-width:768px){
                        .page-wrap{
                            flex-direction:column;
                            align-items:center;
                            gap:20px;
                            padding:20px 14px;
                        }
                        .meter,
                        .card{
                            width:100%;
                            max-width:100%;
                            padding:22px 16px 20px;
                        }
                        .meter-body{
                            flex-direction:column;
                            align-items:center;
                        }
                        .meter-track{
                            min-height:260px;
                            width:12px;
                            margin:0 auto;
                        }
                        .meter-content{
                            width:100%;
                            justify-content:flex-start;
                            gap:14px;
                        }
                        .meter-item{
                            padding-left:0;
                        }
                        .meter-item .meter-item-title{font-size:0.95rem;}
                        .meter-item .meter-item-year{font-size:0.75rem;}
                        .meter-summary{
                            flex-direction:column;
                            align-items:flex-start;
                            gap:10px;
                        }
                        .meter-status{
                            width:100%;
                            text-align:left;
                        }
                        .time-grid{
                            grid-template-columns:repeat(2,1fr);
                            gap:10px;
                        }
                        .time-unit{padding:18px 10px 14px;}
                        .time-value{font-size:clamp(1.6rem,8vw,2.4rem);}
                        .eyebrow{font-size:1.05rem;}
                        h1{font-size:clamp(1.8rem,10vw,2.4rem);}
                        .back-btn{width:100%;padding:14px 0;}
                    }
                </style>
            </head>
            <body>
                <div id="petals"></div>
                <div class="page-wrap">
                    <div class="meter">
                        <div class="meter-title">Monthly milestone meter</div>
                        <div class="meter-body">
                            <div class="meter-content" id="meterItems"></div>
                            <div class="meter-track"><div class="meter-fill" id="meterFill"></div></div>
                        </div>
                        <div class="meter-summary">
                            <span class="meter-count" id="meterMonthCount">Month 1 of 36</span>
                            <span class="meter-next" id="meterNextLabel">Next: Mar 2026 • Growing closer</span>
                        </div>
                        <div class="meter-status" id="meterStatus">Feb 2026 • First spark</div>
                    </div>
                    <div class="card">
                        <div class="eyebrow">&#8212; cool update righttt??? &#8212;</div>
                        <h1>Together Since<br><em>February 16, 2026</em></h1>
                        <div class="gold-line"></div>
                        <p class="sub">Until forever.</p>
                        <div class="time-grid">
                            <div class="time-unit"><span class="time-value" id="days">0</span><span class="time-label">Days</span></div>
                            <div class="time-unit"><span class="time-value" id="hours">0</span><span class="time-label">Hours</span></div>
                            <div class="time-unit"><span class="time-value" id="minutes">0</span><span class="time-label">Minutes</span></div>
                            <div class="time-unit"><span class="time-value" id="seconds">0</span><span class="time-label">Seconds</span></div>
                        </div>
                        <p class="love-note">&#9825; and every one was worth it &#9825;</p>
                        <br>
                        <button class="back-btn" onclick="location.href='/Yas'">&#8592; return home</button>
                    </div>
                </div>
                <script>
                    function updateTimer(){
                        const s=new Date(2026,1,16,0,0,0),n=new Date(),d=n-s;
                        document.getElementById('days').textContent=Math.floor(d/86400000)+1;
                        document.getElementById('hours').textContent=Math.floor((d%86400000)/3600000);
                        document.getElementById('minutes').textContent=Math.floor((d%3600000)/60000);
                        document.getElementById('seconds').textContent=Math.floor((d%60000)/1000);
                    }
                    const monthNames=['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'];
                    const milestoneTitles=[
                        'First spark','Growing closer','Shared memories','Deeper trust','Forever ahead',
                        'Stronger together','More memories','Bright months','Side by side','More warmth',
                        'Shared dreams','Deep connection','Still growing','Always here','Next chapter',
                        'Unseen moments','Warmest days','Deeper smiles','Beautiful changes','Soft whispers',
                        'Future plans','Together onward','Held close','Still going','More laughter',
                        'Stronger roots','More trust','Gentle progress','Quiet nights','Loving seasons',
                        'Full of hope','True companionship','Closer every month','Ever onward','Forever still','Monthly magic'
                    ];
                    const startDate=new Date(2026,1,16,0,0,0);
                    const milestones=Array.from({length:36},(_,i)=>{
                        const date=new Date(2026,1+i,16,0,0,0);
                        return {
                            label:`${monthNames[date.getMonth()]} ${date.getFullYear()}`,
                            title:milestoneTitles[i]
                        };
                    });
                    function renderMilestones(){
                        const html=milestones.map((m,i)=>`
                            <div class="meter-item" data-index="${i}">
                                <div>
                                    <div class="meter-item-title">${m.title}</div>
                                    <div class="meter-item-year">${m.label}</div>
                                </div>
                            </div>
                        `).join('');
                        document.getElementById('meterItems').innerHTML=html;
                    }
                    updateTimer();setInterval(updateTimer,1000);
                    renderMilestones();
                    updateMeter();setInterval(updateMeter,60000);
                    function updateMeter(){
                        const now=new Date();
                        let monthDiff=(now.getFullYear()-startDate.getFullYear())*12 + now.getMonth()-startDate.getMonth();
                        if (now.getDate() < startDate.getDate()) monthDiff -= 1;
                        const index=Math.max(0,Math.min(milestones.length-1,monthDiff));
                        const monthStart=new Date(startDate.getFullYear(), startDate.getMonth()+index, startDate.getDate(), 0, 0, 0);
                        const monthEnd=new Date(startDate.getFullYear(), startDate.getMonth()+index+1, startDate.getDate(), 0, 0, 0);
                        const progress=Math.max(0,Math.min(1,(now-monthStart)/(monthEnd-monthStart)));
                        const totalProgress=Math.min(1,(index + progress)/(milestones.length - 1));
                        const nextIndex=Math.min(index + 1, milestones.length - 1);
                        document.getElementById('meterFill').style.height=`${totalProgress*100}%`;
                        document.querySelectorAll('.meter-item').forEach((item,i)=>{
                            item.classList.toggle('active', i===index);
                            item.classList.toggle('next', i===nextIndex && i!==index);
                        });
                        document.getElementById('meterMonthCount').textContent=`Month ${index + 1} of ${milestones.length}`;
                        document.getElementById('meterNextLabel').textContent = nextIndex > index
                            ? `Next: ${milestones[nextIndex].label} • ${milestones[nextIndex].title}`
                            : `Next: Completed`;
                        document.getElementById('meterStatus').textContent=`${milestones[index].label} • ${milestones[index].title}`;
                    }
                    const pc=document.getElementById('petals');
                    const ps=['\u2665','\u2661','\u2764','\u273F'];
                    const col=['#ffffff','#7ca9ff','#ffffff'];
                    function sp(){
                        const p=document.createElement('div');p.className='petal';
                        p.textContent=ps[Math.floor(Math.random()*ps.length)];
                        p.style.left=Math.random()*100+'vw';
                        p.style.color=col[Math.floor(Math.random()*col.length)];
                        p.style.fontSize=(0.7+Math.random()*1.1)+'rem';
                        p.style.animationDuration=(7+Math.random()*9)+'s';
                        p.style.animationDelay=(Math.random()*3)+'s';
                        pc.appendChild(p);setTimeout(()=>p.remove(),16000);
                    }
                    setInterval(sp,1200);for(let i=0;i<6;i++)setTimeout(sp,i*350);
                </script>
            </body>
            </html>
            """, "text/html", System.Text.Encoding.UTF8);
        });
    }
}
