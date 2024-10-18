FROM node:lts-alpine
WORKDIR /app
ENV PNPM_HOME="/pnpm"
ENV PATH="$PNPM_HOME:$PATH"
RUN corepack enable
COPY package*.json ./
RUN pnpm install
COPY . .
RUN pnpm run build
ENV NODE_ENV=production
CMD ["node", ".output/server/index.mjs"]
EXPOSE 3000