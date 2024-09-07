# Stage 1: Build the Angular application
FROM node:18 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy package.json and package-lock.json
COPY package*.json ./

# Install dependencies
RUN npm install

# Copy the rest of the application code
COPY . .

# Build the Angular app in production mode
RUN npm run build --prod

# Stage 2: Serve the application with Nginx
FROM nginx:alpine

# Copy the built Angular app from the build stage to the Nginx html folder
COPY --from=build /app/dist/stone /usr/share/nginx/html

# Copy the custom Nginx configuration file (optional)
COPY nginx.conf /etc/nginx/nginx.conf

# Expose the port that Nginx will use
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]