import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/service/api.service';
import { CartService } from 'src/app/service/cart.service';
import { IProduct } from '../admin-product/IProduct';

@Component({
  selector: 'app-viewproduct',
  templateUrl: './viewproduct.component.html',
  styleUrls: ['./viewproduct.component.css']
})
export class ViewproductComponent implements OnInit {
  public productList : any ;
  pQuantity:number=0;
  public cartItemList : any = [];

  constructor(private activatedRoute:ActivatedRoute,private apiService:ApiService,private cartService:CartService) { 
    this.activatedRoute.paramMap.subscribe(params => {
      const id=params.get('id');
      const id2=new Number(id);
      console.log(id);
      this.apiService.getProductById(id2).subscribe(product=>{
        this.productList=product;
        console.log(this.productList);
      });
  });
  
  
  }
  


  ngOnInit(): void {
  }
  
  addtocart(productList: any,pQuantity:number){
    this.cartService.addtoCart(productList,pQuantity);
}

}