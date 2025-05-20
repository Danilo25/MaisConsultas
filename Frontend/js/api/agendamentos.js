const API_BASE = "http://localhost:5000";

export async function listarAgendamentos(filtros = {}) {
  const params = new URLSearchParams(filtros).toString();
  const response = await fetch(`${API_BASE}/api/agendamentos?${params}`);
  if (!response.ok) throw new Error("Erro ao buscar agendamentos");
  return await response.json();
}

export async function agendarConsulta(dados) {
  const response = await fetch(`${API_BASE}/api/agendamentos`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(dados)
  });
  if (!response.ok) throw new Error("Erro ao agendar consulta");
  return await response.json();
}