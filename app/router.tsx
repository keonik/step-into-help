import { MutationCache, QueryClient } from "@tanstack/react-query";
import { createRouter as createTanStackRouter } from "@tanstack/react-router";
import { routerWithQueryClient } from "@tanstack/react-router-with-query";
import { routeTree } from "./routeTree.gen";
import { DefaultCatchBoundary } from "@/components/DefaultCatchBoundary";
import { NotFound } from "@/components/NotFound";
// NOTE: Most of the integration code found here is experimental and will
// definitely end up in a more streamlined API in the future. This is just
// to show what's possible with the current APIs.

export function createRouter() {
  const queryClient = new QueryClient({
    defaultOptions: {
      queries: {
        gcTime: 1000 * 60 * 60 * 24, // 24 hours
        staleTime: 2000,
        retry: 0,
      },
    },
    // configure global cache callbacks to show toast notifications
    mutationCache: new MutationCache({
      onSuccess: (data) => {
        // toast.success(data.message);
      },
      onError: (error) => {
        // toast.error(error.message);
      },
    }),
  });

  // we need a default mutation function so that paused mutations can resume after a page reload
  // queryClient.setMutationDefaults(movieKeys.all(), {
  //   mutationFn: async ({ id, comment }) => {
  //     // to avoid clashes with our optimistic update when an offline mutation continues
  //     await queryClient.cancelQueries({ queryKey: movieKeys.detail(id) });
  //     return api.updateMovie(id, comment);
  //   },
  // });

  return routerWithQueryClient(
    createTanStackRouter({
      routeTree,
      context: { queryClient },

      defaultPreload: "intent",
      defaultErrorComponent: DefaultCatchBoundary,
      defaultNotFoundComponent: () => <NotFound />,
    }),

    queryClient
  );
}

declare module "@tanstack/react-router" {
  interface Register {
    router: ReturnType<typeof createRouter>;
  }
}
