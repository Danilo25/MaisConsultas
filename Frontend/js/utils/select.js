export function adicionarPlaceholder(select, texto = "Selecionar...") {
  const option = document.createElement("option");
  option.textContent = texto;
  option.value = "";
  option.disabled = true;
  option.selected = true;
  select.prepend(option);
}