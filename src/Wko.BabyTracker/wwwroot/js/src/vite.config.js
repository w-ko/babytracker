import { defineConfig } from 'vite'

export default defineConfig({
    build: {
        sourcemap: true,
        
        rollupOptions: {
            // overwrite default .html entry
            input: 'main.js',
            output: {
                manualChunks: false,
                inlineDynamicImports: true,
                entryFileNames: '[name].js',
                assetFileNames: 'bundled.min.[ext]',
            }
            
        },
        outDir: '../',
        emptyOutDir: true,
    },
})
