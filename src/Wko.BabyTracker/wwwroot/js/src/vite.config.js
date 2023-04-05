import { defineConfig } from "vite";

export default defineConfig({
  esbuild: {
    minifyIdentifiers: false,
  },
  build: {
    sourcemap: true,

    lib: {
      entry: "main.js",
      formats: ["es"],
      fileName: "bundled.min",
      minify: true,
    },

    outDir: "../dist",
    emptyOutDir: true,
  },
});
