import { useEffect } from 'react'
import { orderHub } from '../services/signalrService'

export const useSignalR = () => {
  useEffect(() => {
    void orderHub.start()
    return () => { void orderHub.stop() }
  }, [])
}
