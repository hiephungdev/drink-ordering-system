# DrinkOrderingSystem

Monorepo scaffold cho he thong dat nuoc gom customer app, staff dashboard va ASP.NET Core backend.

## Kien truc

- `backend/src/DrinkOrderingSystem.Domain`: entity, enum, base type va repository contracts; khong phu thuoc layer ngoai.
- `backend/src/DrinkOrderingSystem.Application`: CQRS/MediatR, DTO va application contracts.
- `backend/src/DrinkOrderingSystem.Infrastructure`: EF Core PostgreSQL, JWT service, repositories se bo sung, va SignalR `OrderHub`.
- `backend/src/DrinkOrderingSystem.API`: HTTP controllers, middleware, Swagger, CORS, authentication va endpoint SignalR.
- `frontend/customer-app`: giao dien khach dat mon.
- `frontend/staff-dashboard`: giao dien nhan don/kitchen display.

## Yeu cau moi truong

- .NET SDK 8
- Node.js va npm
- Docker Desktop (neu chay database/backend bang Compose)

## Chay PostgreSQL va backend bang Docker

```bash
docker compose up --build
```

Backend chay tai `http://localhost:5000`; PostgreSQL expose tai port `5432`.

## Chay local ca 3 phan

Terminal 1:

```bash
cd backend
dotnet run --project src/DrinkOrderingSystem.API
```

Terminal 2:

```bash
cd frontend/customer-app
npm install
npm run dev
```

Customer app: `http://localhost:5173`.

Terminal 3:

```bash
cd frontend/staff-dashboard
npm install
npm run dev
```

Staff dashboard: `http://localhost:5174`.

## EF Core migrations

Sau khi hoan thien entity va DbContext, chay tu thu muc `backend`:

```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate \\
  --project src/DrinkOrderingSystem.Infrastructure \\
  --startup-project src/DrinkOrderingSystem.API \\
  --output-dir Persistence/Migrations

dotnet ef database update \\
  --project src/DrinkOrderingSystem.Infrastructure \\
  --startup-project src/DrinkOrderingSystem.API
```

Thu muc `Persistence/Migrations` da duoc tao san bang `.gitkeep`; scaffold nay chua tao migration that.

## Cau hinh moi truong

Copy `.env.example` thanh `.env` neu can tuy chinh. Frontend doc cac bien `VITE_API_URL` va `VITE_SIGNALR_HUB_URL`. Backend doc bien ASP.NET configuration tu `.env.example` khi duoc nap vao moi truong chay.

## Trang thai scaffold

Cac controller, CQRS handlers, SignalR callbacks va UI components hien la khung boilerplate. Chua co logic dat mon, xac thuc nguoi dung, cap nhat trang thai don hay phat su kien real-time.
