# Usa uma imagem leve de servidor HTTP
FROM nginx:alpine

# Remove a configuração padrão do NGINX
RUN rm -rf /usr/share/nginx/html/*

# Copia os arquivos do frontend para o NGINX
COPY . /usr/share/nginx/html

# Expõe a porta padrão do NGINX
EXPOSE 80