import {defineConfig} from 'vite'

export default defineConfig({
    esbuild: {
        minifyIdentifiers: false,
    },
    build: {
        sourcemap: true,

        lib: {
            entry: 'main.js',
            name: 'BabyTracker',
            formats: ["es"],
            fileName: 'bundled.min',
        },

        outDir: '../dist',
        emptyOutDir: true,
        
    },
})
