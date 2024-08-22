/// <reference types="vite/client" />

interface ImportMetaEnv {
    readonly VITE_APP_API_DEV_URL: string
    readonly VITE_APP_API_PROD_URL: string
}
  
interface ImportMeta {
    readonly env: ImportMetaEnv
}