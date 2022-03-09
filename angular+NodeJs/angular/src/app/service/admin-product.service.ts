import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { UpdateProductComponent } from '../pages/update-product/update-product.component';
// import { IProduct } from '../pages/admin-product/IProduct';

@Injectable({
  providedIn: 'root'
})

export class AdminProductService {
  baseUrl='https://localhost:44362/api/Products';



  // httpOptions = {
  //   headers: new HttpHeaders({'Content-Type':'application/json'})
  // };


  constructor(private httpclient:HttpClient) { }

  createProduct(Products: any): Observable<any> {
    return this.httpclient.post(this.baseUrl, Products);
  }
 


  

  delete(id: number):Observable<any>{
    return this.httpclient.delete<any>(`https://localhost:44362/api/Products/${id}`)
     }

  getProduct(){

    return this.httpclient.get<any>(`https://localhost:44362/api/Products`)
    .pipe(map((resp:any)=>{
      return resp;
   }))
  }

   UpdateProduct(id:Number,title:String,price:Number,description:String,category:String,image:String)
   {
      const products={Id:id,Title:title,Price:price,Description:description,Category:category,Image:image};
       //console.log(products);
      return this.httpclient.put<any>('https://localhost:44362/api/Products',products)
        .pipe(map((res:any)=>{
          return res;
        }))
           
  
  }

  

 

}

