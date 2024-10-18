FROM cgr.dev/chainguard/node AS base
USER root
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
FROM base AS runner
USER root
WORKDIR /app
COPY --from=base /app/.output .
EXPOSE 3000
ENV PORT 3000
CMD ["node", ".output/server/index.mjs"]