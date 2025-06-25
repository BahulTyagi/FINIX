import React from 'react'
import './Navbar.css'
import { Link } from 'react-router-dom'
import { useAuth } from '../../Context/useAuth'
type Props = {}

const Navbar = (props: Props) => {


  const{isLoggedIn, user, logout}=useAuth();

  const onLoginClick=()=>{
  }

  const onRegisterClick=()=>{
    
  }

  return (
    <div className='navbar'>
      <Link to="/"><div>FINIX</div></Link>
      <div className='buttons'>
        {!isLoggedIn()?(
          <>
          <Link to="/login" className='button' onClick={onRegisterClick}>Login</Link>
          
          <Link to="/register" className='button' onClick={onRegisterClick}>Signup</Link>
          </>
      )
          :
          (
          <Link to="/login" className='button' onClick={onRegisterClick}>Logout</Link>
          )
      }
          </div>
    </div>
  )
}

export default Navbar