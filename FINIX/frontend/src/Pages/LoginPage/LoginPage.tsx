import React from 'react';
import * as Yup from "yup";  // npm i react-hook-form yup @hookform/resolvers   // this is used to build forms, with validations pre defined in it.
import { useAuth } from '../../Context/useAuth';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';

type Props = {}


type LoginFormInputs={
    userName: string,
    password: string
}

const validation=Yup.object().shape({
    userName: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required"),
});

const LoginPage = (props: Props) => {
    const{loginUser}=useAuth();

    const{register, handleSubmit, formState:{errors},}=useForm<LoginFormInputs>({resolver: yupResolver(validation)});


    const handleLogin=(form: LoginFormInputs)=>{
        loginUser(form.userName, form.password);
    }



  return (
    <>
        <form onSubmit={handleSubmit(handleLogin)}>
            <input type="text" {...register("userName")} placeholder='userName' />
            <input type="password" {...register("password")} placeholder='password' />
            <button>Login</button>
        </form>
    </>
  )
}

export default LoginPage