FROM nginx:1.13.12-alpine
EXPOSE 4200
#RUN apk update
COPY default.conf /etc/nginx/conf.d/default.conf
RUN rm -rf /var/www/html/*
COPY static.json /var/www/html/static.json
#COPY static.json /var/www/static.json
WORKDIR /var/www/html
CMD ["nginx", "-g", "daemon off;"]
