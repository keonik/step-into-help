FROM node:20-alpine AS base
USER root
ENV PATH /app/node_modules/.bin:$PATH
ENV PATH /usr/sbin/bin:$PATH
WORKDIR /app
COPY . /app
COPY package.json yarn.lock* package-lock.json* pnpm-lock.yaml\* ./
RUN npm i --frozen-lockfile

RUN \
 if [ -f yarn.lock ]; then yarn build; \
 elif [ -f package-lock.json ]; then npm run build; \
 elif [ -f pnpm-lock.yaml ]; then pnpm run build; \
 else echo "Lockfile not found." && exit 1; \
 fi

# Create an optimised runner image
FROM node:20-alpine AS runner
USER node
ENV PATH /app/node_modules/.bin:$PATH

WORKDIR /app
COPY --from=base --chown=node:node /app/.output .output
EXPOSE 3000
ENV PORT 3000
CMD ["node", ".output/server/index.mjs"]