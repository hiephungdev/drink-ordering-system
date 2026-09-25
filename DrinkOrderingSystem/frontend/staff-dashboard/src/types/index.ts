export type OrderStatus = 'Pending' | 'Confirmed' | 'Preparing' | 'Ready' | 'Completed' | 'Cancelled'
export type Order = { id: string; tableId: string; status: OrderStatus; createdAt: string; totalPrice: number }
