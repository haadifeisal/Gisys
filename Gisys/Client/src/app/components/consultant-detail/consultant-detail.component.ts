import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FlashMessagesService } from 'angular2-flash-messages';
import { Consultant } from 'src/app/models/Consultant';
import { ConsultantService } from 'src/app/services/consultant.service';
import { FormGroup, FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { EditConsultantComponent } from '../edit-consultant/edit-consultant.component';

@Component({
  selector: 'app-consultant-detail',
  templateUrl: './consultant-detail.component.html',
  styleUrls: ['./consultant-detail.component.css']
})
export class ConsultantDetailComponent implements OnInit {

  consultant: Consultant;
  id: string;
  shareOfBonusPot: string;
  bonus: string;

  constructor(
    private consultantService: ConsultantService,
    private router: ActivatedRoute,
    private route: Router,
    private flashM: FlashMessagesService,
    private fb: FormBuilder, 
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    

    this.shareOfBonusPot = '';
    this.id = this.router.snapshot.params['id'];
    this.consultantService.getConsultant(this.id).subscribe((data: Consultant) => {
      this.consultant = data;
      this.getConsultantShareOfBonus();
      this.getConsultantBonus();
    })
  }

  getConsultantShareOfBonus(){
    this.consultantService.getConsultantShareOfBonusPot(this.id).subscribe((data) => {
      this.shareOfBonusPot = data;
    })
  }

  getConsultantBonus(){
    this.consultantService.getConsultantBonusPot(this.id, 100000).subscribe((data) => {
      this.bonus = data;
    })
  }

  openModal(consultant:Consultant) {
    const ref = this.modalService.open(EditConsultantComponent)

    ref.componentInstance.consultant = consultant;

    ref.result.then((yes) => {
      this.consultantService.getConsultant(this.id).subscribe((data: Consultant) => {
        this.consultant = data;
        this.getConsultantShareOfBonus();
        this.getConsultantBonus();
      });
    },
    (cancel) => {
      console.log("Cancel Click");
    })

   }

   deleteConsultant(consultantId: string){
    if(confirm("Are you sure you want to delete consultant " + this.consultant.name)) {
      this.consultantService.deleteConsultant(this.id).subscribe((data: boolean) => {
        if(data == true){
          this.route.navigate(['/consultants']);
        }
      })
    }
    
   }


}
