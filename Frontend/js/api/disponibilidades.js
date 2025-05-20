const API_BASE = "http://localhost:5000";

export async function definirDisponibilidade(disponibilidade) {
  const response = await fetch(`${API_BASE}/api/disponibilidades/definir`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(disponibilidade)
  });
  if (!response.ok) throw new Error("Erro ao cadastrar disponibilidade");
  return await response.json();
}

export async function buscarHorarios(especialidadeId, data, medico = null) {
  const payload = { especialidadeId, data };
  if (medico) payload.medico = medico;

  const response = await fetch(`${API_BASE}/api/disponibilidades`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(payload)
  });
  if (!response.ok) throw new Error("Erro ao buscar horários disponíveis");
  return await response.json();
}

export async function listarDisponibilidades(filtros = {}) {
  const params = new URLSearchParams(filtros).toString();
  const response = await fetch(`${API_BASE}/api/disponibilidades?${params}`);
  if (!response.ok) throw new Error("Erro ao buscar disponibilidades");
  return await response.json();
}