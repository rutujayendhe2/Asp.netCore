import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminProductService } from 'src/app/service/admin-product.service';
import { ApiService } from 'src/app/service/api.service';

@Component({
  selector: 'app-update-product',
  templateUrl: './update-product.component.html',
  styleUrls: ['./update-product.component.css']
})
export class UpdateProductComponent implements OnInit {
  product:any;
   updated:boolean | undefined;
  productForm: FormGroup;
  image!: string;
  imagePreview: string | undefined;
  constructor(private activatedRoute:ActivatedRoute,private apiService:ApiService,private aproductservice:AdminProductService,private route:Router) { 
    this.activatedRoute.paramMap.subscribe(params => {
      const id=params.get('id');
      const id2=new Number(id);
      this.apiService.getProductById(id2).subscribe(res=>{
        this.product=res;
        console.log(this.product);
      });
    });


    this.productForm=new FormGroup({

      productId:new FormControl(null,{validators:Validators.required}),

      productName:new FormControl(null,{validators:Validators.required}),

      category:new FormControl(null,{validators:[Validators.required]}),

      productPrice:new FormControl({Validators:[Validators.required]}),

      productDescription:new FormControl({Validators:[Validators.required]}),

      image:new FormControl({Validators:[Validators.required]})

    });
  }

  
  handleImageFile(e:Event){

    const target = e.target as HTMLInputElement;
    if (target.files && target.files.length > 0) {
        console.log(target.files[0].name);

     const file = target.files[0].name;

  //   const path=file.name;

      this.image=`../../../assets/${file}`;

  //   this.productForm.patchValue({image:file})

  //   this.productForm.get('image').updateValueAndValidity();

  //   const reader=new FileReader();

  //   reader.onload=()=>{

  //     this.imagePreview=reader.result as string;

  //   };

  //  reader.readAsDataURL(file);

   }
  }
  updateProduct(){
     console.log(this.productForm.value);
    this.aproductservice.UpdateProduct(this.productForm.value.productId,
      this.productForm.value.productName,
      this.productForm.value.productPrice,
      this.productForm.value.productDescription,

      this.productForm.value.category,
      this.image,

      ).subscribe((res:any) => {
        alert('Product Details updated successfully!');
        this.route.navigateByUrl('/admin-product');
   })
  }

  ngOnInit(): void {
  }

}

