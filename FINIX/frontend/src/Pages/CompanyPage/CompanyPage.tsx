import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router'
import type { CompanyProfile } from '../../company';
import { getCompanyProfile } from '../../api';

type Props = {}

const CompanyPage = (props: Props) => {
    
    let {ticker}=useParams();

    const[company, setCompany]=useState<CompanyProfile>();

    useEffect(()=>{
        const getProfileInit=async()=>{
            const result=await getCompanyProfile(ticker!);
            setCompany(result?.data[0]);
        }
        getProfileInit();
    },[])

  return (
    <div>{company && <div>{company.companyName}</div>}</div>
  )
}

export default CompanyPage