
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IProduct } from '../pages/admin-product/IProduct';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

    constructor(private http : HttpClient) { }

// Method to call all products from productlist web API
    getProduct(){
          return this.http.get<any>("https://localhost:44362/api/Products")
          .pipe(map((resp:any)=>{
            return resp;
          }))
        }


        
      

    getProductById(id:Number):Observable<any>{
      console.log(id);

      return this.http.get<any>('https://localhost:44362/api/Products/'+id);
    
    }

}
