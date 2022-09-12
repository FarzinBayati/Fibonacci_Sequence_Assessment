FROM nginx:stable

RUN mkdir -p /usr/src/fiboapp

COPY ["src/frontend","/usr/src/fiboapp"]
COPY ["src/frontend/nginx.conf","/etc/nginx/conf.d/default.conf"]

RUN mkdir -p /var/www/html
RUN cp -r /usr/src/fiboapp/* /var/www/html

RUN nginx
