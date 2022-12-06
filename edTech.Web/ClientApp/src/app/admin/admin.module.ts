import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { CourseComponent } from './course/course.component';
import { CoursesComponent } from './courses/courses.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { LessonComponent } from './lesson/lesson.component';
import { LessonsComponent } from './lessons/lessons.component';
import { MentorComponent } from './mentor/mentor.component';
import { MentorsComponent } from './mentors/mentors.component';
import { TopicComponent } from './topic/topic.component';
import { TopicsComponent } from './topics/topics.component';


@NgModule({
  declarations: [
    CourseComponent,
    CoursesComponent,
    DashboardComponent,
    LessonComponent,
    LessonsComponent,
    MentorComponent,
    MentorsComponent,
    TopicComponent,
    TopicsComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
