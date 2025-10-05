// ------------------------------------------------------------
// TeamAlpha - Clean Site Script
// ------------------------------------------------------------
// Handles: Current year, Portfolio filters, Builder estimate,
// Animated background particles, Dark mode toggle
// ------------------------------------------------------------

// ---------- UTIL: Safe query ----------
const $ = (sel) => document.querySelector(sel);
const $$ = (sel) => document.querySelectorAll(sel);

// ---------- 1. CURRENT YEAR ----------
document.addEventListener("DOMContentLoaded", () => {
    const yearEl = $("#year");
    if (yearEl) yearEl.textContent = new Date().getFullYear();
});

// ---------- 2. PORTFOLIO FILTERS ----------
(() => {
    const grid = $("#portfolioGrid");
    if (!grid) return; // skip if not on portfolio page

    const items = Array.from(grid.querySelectorAll(".portfolio-item"));
    $$(".filter-btns .btn").forEach((btn) => {
        btn.addEventListener("click", () => {
            // reset all buttons
            $$(".filter-btns .btn").forEach((b) =>
                b.classList.replace("btn-dark", "btn-outline-dark")
            );
            btn.classList.remove("btn-outline-dark");
            btn.classList.add("btn-dark");

            const filter = btn.dataset.filter;
            items.forEach((card) => {
                const show =
                    filter === "*" ||
                    card.dataset.tags.split(" ").includes(filter);
                card.style.display = show ? "" : "none";
            });
        });
    });
})();

// ---------- 3. BUILDER MOCK ESTIMATE ----------
(() => {
    const form = $("#builderForm");
    const output = $("#estimateContent");
    if (!form || !output) return; // only run on builder page

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        const data = new FormData(form);
        const type = data.get("type");
        const size = parseInt(data.get("size") || 0, 10);
        const floors = parseInt(data.get("floors") || 1, 10);
        const budget = data.get("budget");
        const style = data.get("style");

        const baseline = type === "Commercial" ? 260 : 180; // $/sqft rough
        const factor =
            style === "Sustainable"
                ? 1.12
                : style === "Minimalist"
                    ? 1.02
                    : 1.0;

        const estimate = Math.round(size * baseline * factor);

        output.innerHTML = `
            <div class="mb-2"><strong>Scope Summary</strong></div>
            <ul class="mb-2">
                <li>Type: ${type}</li>
                <li>Size: ${size.toLocaleString()} sqft • Floors: ${floors}</li>
                <li>Style: ${style}</li>
                <li>Budget target: ${budget}</li>
            </ul>
            <div class="mb-2">Rough build estimate (ex-site, fees): 
                <strong>$${estimate.toLocaleString()}</strong>
            </div>
            <a class="btn btn-sm btn-primary" href="#contact">Proceed to Consultation</a>
        `;
        output.parentElement.scrollIntoView({ behavior: "smooth" });
    });
})();

// ---------- 4. BACKGROUND PARTICLES ----------
(() => {
    const canvas = $("#bgCanvas");
    if (!canvas) return;

    const ctx = canvas.getContext("2d");
    let particles = [];

    function resizeCanvas() {
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;
    }
    window.addEventListener("resize", resizeCanvas);
    resizeCanvas();

    // Create particles once
    for (let i = 0; i < 600; i++) {
        particles.push({
            x: Math.random() * canvas.width,
            y: Math.random() * canvas.height,
            r: Math.random() * 3 + 1,
            dx: (Math.random() - 0.5) * 1.5,
            dy: (Math.random() - 0.5) * 1.5,
        });
    }

    function draw() {
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.fillStyle = "#0d6efd33"; // bluish accent
        particles.forEach((p) => {
            ctx.beginPath();
            ctx.arc(p.x, p.y, p.r, 0, Math.PI * 2);
            ctx.fill();

            p.x += p.dx;
            p.y += p.dy;

            if (p.x < 0 || p.x > canvas.width) p.dx *= -1;
            if (p.y < 0 || p.y > canvas.height) p.dy *= -1;
        });
        requestAnimationFrame(draw);
    }
    draw();
})();

// ---------- 5. DARK MODE TOGGLE ----------
(() => {
    const body = document.body;
    const toggleBtn = $("#themeToggle");
    const icon = $("#themeIcon");
    if (!toggleBtn || !icon) return;

    // Load saved theme
    const saved = localStorage.getItem("theme");
    if (saved === "dark") {
        body.classList.add("dark-mode");
        icon.classList.replace("bi-moon-fill", "bi-sun-fill");
    }

    // Toggle handler
    toggleBtn.addEventListener("click", () => {
        const isDark = body.classList.toggle("dark-mode");
        icon.classList.replace(
            isDark ? "bi-moon-fill" : "bi-sun-fill",
            isDark ? "bi-sun-fill" : "bi-moon-fill"
        );
        localStorage.setItem("theme", isDark ? "dark" : "light");
    });
})();
