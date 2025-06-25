import * as Yup from "yup";  // npm i react-hook-form yup @hookform/resolvers   // this is used to build forms, with validations pre defined in it.
import { useAuth } from '../../Context/useAuth';
import { useForm } from 'react-hook-form';
import { yupResolver } from '@hookform/resolvers/yup';

type Props = {}


type RegisterFormInputs={
    email: string,
    userName: string,
    password: string
}

const validation=Yup.object().shape({
    email: Yup.string().required("email is required"),
    userName: Yup.string().required("Username is required"),
    password: Yup.string().required("Password is required"),
});

const RegisterPage = (props: Props) => {
    const{registerUser}=useAuth();

    const{register, handleSubmit, formState:{errors},}=useForm<RegisterFormInputs>({resolver: yupResolver(validation)});


    const handleRegister=(form: RegisterFormInputs)=>{
        registerUser(form.email, form.userName, form.password);
    }



  return (
    <>
        <form onSubmit={handleSubmit(handleRegister)}>
             <input type="text" {...register("email")} placeholder='email' />
            <input type="text" {...register("userName")} placeholder='userName' />
            <input type="text" {...register("password")} placeholder='password' />
            <button>Register</button>
        </form>
    </>
  )
}

export default RegisterPage