// app/client.tsx
/// <reference types="vinxi/types/client" />
import { hydrateRoot } from "react-dom/client";
import { StartClient } from "@tanstack/start";
import { createRouter } from "./router";

const router = createRouter();

// biome-ignore lint/style/noNonNullAssertion: https://tanstack.com/router/latest/docs/framework/react/start/getting-started#the-client-entry-point
hydrateRoot(document.getElementById("root")!, <StartClient router={router} />);
