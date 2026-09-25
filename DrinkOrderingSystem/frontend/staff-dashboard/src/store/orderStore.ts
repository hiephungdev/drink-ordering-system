import { create } from 'zustand'
import type { Order } from '../types'

type OrderState = { orders: Order[]; setOrders: (orders: Order[]) => void }

export const useOrderStore = create<OrderState>((set) => ({
  orders: [],
  setOrders: (orders) => set({ orders }),
}))
