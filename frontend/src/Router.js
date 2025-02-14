import { useRoutes, Navigate } from "react-router-dom";
import Home from "./pages/home";
import Employees from "./pages/employees";
import Management from "./pages/management";
import OsEmployees from "./pages/osEmployees";
import AddEmployee from "./pages/addEmployee"; // ייבוא העמוד החדש

export default function Router() {
  const elements = useRoutes([
    { path: "home", element: <Home /> },
    { path: "employees", element: <Employees /> },
    { path: "management", element: <Management /> },
    { path: "osEmployees", element: <OsEmployees /> },
    { path: "add-employee", element: <AddEmployee /> }, // נתיב חדש
    { path: "/", element: <Navigate to="home" /> },
    { path: "*", element: <Navigate to="/" /> },
  ]);

  return <>{elements}</>;
}
