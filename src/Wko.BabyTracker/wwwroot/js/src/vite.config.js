import {defineConfig} from 'vite'

export default defineConfig({
    esbuild: {
        minifyIdentifiers: false,
    },
    build: {
        sourcemap: true,

        lib: {
            entry: 'main.js',
            name: 'babyTracker',
            formats: ["iife"],
            fileName: 'bundled.min',
        },

        outDir: '../dist',
        emptyOutDir: true,
        
    },
})
