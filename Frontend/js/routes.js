const routes = {
  "/dashboard.html": "componentes/pages/dashboard.html",
  "/cadastro_especialidades.html": "componentes/pages/cadastro_especialidades.html",
  "/cadastro_convenios.html": "componentes/pages/cadastro_convenios.html",
  "/cadastro_disponibilidades.html": "componentes/pages/cadastro_disponibilidades.html",
  "/agendamento.html": "componentes/pages/agendamento.html",
  "/consultas.html": "componentes/pages/consultas.html"
};

async function loadPage() {
  const path = location.pathname;
  const page = routes[path] || routes["/dashboard.html"];
  const html = await fetch(page).then(res => res.text());
  document.getElementById("main-content").innerHTML = html;

  // JS específico por página
  switch (path) {
    case "/cadastro_especialidades.html":
      import("./pages/cadastro_especialidades.js").then(m => m.init?.());
      break;
    case "/cadastro_convenios.html":
      import("./pages/cadastro_convenios.js").then(m => m.init?.());
      break;
    case "/cadastro_disponibilidades.html":
      import("./pages/cadastro_disponibilidades.js").then(m => m.init?.());
      break;
    case "/agendamento.html":
      import("./pages/agendamento.js").then(m => m.init?.());
      break;
    case "/consultas.html":
      import("./pages/consultas.js").then(m => m.init?.());
      break;
  }
}

window.addEventListener("popstate", loadPage);
window.addEventListener("DOMContentLoaded", loadPage);