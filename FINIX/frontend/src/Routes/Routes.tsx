import { createBrowserRouter } from "react-router";
import App from "../App";
import HomePage from "../Pages/HomePage/HomePage";
import SearchPage from "../Pages/SearchPage/SearchPage";
import CompanyPage from "../Pages/CompanyPage/CompanyPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import RegisterPage from "../Pages/RegisterPage/RegisterPage";
import ProtectedRoute from "./ProtectedRoute";

export const router=createBrowserRouter([
    {
        path:"/",
        element:<App/>,
        children:[
            {
                path:"", element:<ProtectedRoute><HomePage/></ProtectedRoute>
            },
            {
                path:"login", element:<LoginPage/>
            },
            {
                path:"register", element:<RegisterPage/>
            },
            {
                path:"search", element:<ProtectedRoute><SearchPage/></ProtectedRoute>
            },
            {
                path:"company/:ticker", element:<ProtectedRoute><CompanyPage/></ProtectedRoute>
            }
        ]
    }
])