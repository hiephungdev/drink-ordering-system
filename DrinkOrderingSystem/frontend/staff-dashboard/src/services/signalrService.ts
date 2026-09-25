import { HubConnectionBuilder } from '@microsoft/signalr'

export const orderHub = new HubConnectionBuilder()
  .withUrl(import.meta.env.VITE_SIGNALR_HUB_URL ?? 'http://localhost:5000/hubs/orders')
  .withAutomaticReconnect()
  .build()
