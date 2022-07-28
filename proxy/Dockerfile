FROM nginx:alpine AS final
EXPOSE 80
WORKDIR /usr/share/nginx/html
COPY "proxy/nginx.conf" /etc/nginx/nginx.conf