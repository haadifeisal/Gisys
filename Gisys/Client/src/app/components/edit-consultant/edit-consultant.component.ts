import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Consultant } from 'src/app/models/Consultant';
import { ConsultantRequest } from 'src/app/models/ConsultantRequest';
import { ConsultantService } from 'src/app/services/consultant.service';

@Component({
  selector: 'app-edit-consultant',
  templateUrl: './edit-consultant.component.html',
  styleUrls: ['./edit-consultant.component.css']
})
export class EditConsultantComponent implements OnInit {

  consultant: Consultant;
  consultantRequest: ConsultantRequest = {
    name : '',
    yearOfEmployment: 0,
    chargedHours: 0
  };

  editForm: FormGroup;
  constructor(public modal: NgbActiveModal, private route: ActivatedRoute, private consultantService: ConsultantService, private formBuilder: FormBuilder, private router: Router) { }

  ngOnInit() {
    this.setForm(this.consultant);
  }

  onSubmit() {
    console.log("HEEJJJ: ", this.editForm.value.name);

    this.consultantRequest.name = this.editForm.value.name;
    this.consultantRequest.yearOfEmployment = this.editForm.value.yearOfEmployment;
    this.consultantRequest.chargedHours = this.editForm.value.chargedHours;

    this.consultantService.updateConsultant(this.consultant.consultantId, this.consultantRequest).subscribe(x => {
        this.modal.close();
    },
      error => {
        
      });
  }

  get editFormData() { return this.editForm.controls; }

  private setForm(consultant: Consultant) {
    this.editForm = this.formBuilder.group({
      name: [consultant.name, Validators.required],
      yearOfEmployment: [consultant.yearOfEmployment, Validators.required],
      chargedHours: [ consultant.chargedHours, [Validators.required]]
    });

  }

}
