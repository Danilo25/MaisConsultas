fetch("componentes/sidebar.html")
  .then(res => res.text())
  .then(html => {
    document.getElementById("sidebar").innerHTML = html;

    document.querySelectorAll(".menu-toggle").forEach(toggle => {
      toggle.addEventListener("click", () => {
        const submenu = document.getElementById(toggle.dataset.target);
        submenu?.classList.toggle("visible");
      });
    });

    document.querySelectorAll(".side-menu a").forEach(link => {
      link.addEventListener("click", e => {
        e.preventDefault();
        const path = new URL(e.target.href).pathname;
        history.pushState({}, "", path);
        window.dispatchEvent(new Event("popstate"));
      });
    });
  });