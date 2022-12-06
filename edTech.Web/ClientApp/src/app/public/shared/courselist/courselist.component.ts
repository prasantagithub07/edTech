import { Component, OnInit } from '@angular/core';
import { Course } from 'src/app/models/course';
import { CartService } from 'src/app/services/cart.service';
import { CatalogService } from 'src/app/services/catalog.service';

@Component({
  selector: 'app-courselist',
  templateUrl: './courselist.component.html',
  styleUrls: ['./courselist.component.css']
})
export class CourselistComponent implements OnInit {
  message: string | any;
  courses: Course[] | any;
  constructor(private catalogService: CatalogService, private cartService: CartService) { }

  ngOnInit(): void {
    this.catalogService.GetCourses().subscribe(res => {
      if(res.status == 200){
        this.courses = res.body;
        console.log(this.courses);
      }
    });
  }
  AddToCart(id: number, name: string, unitPrice: number, quantity: number, image: string){
    
  }

}
