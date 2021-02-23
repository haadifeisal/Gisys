import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ConsultantRequest } from 'src/app/models/ConsultantRequest';
import { ConsultantService } from 'src/app/services/consultant.service';

@Component({
  selector: 'app-add-consultant',
  templateUrl: './add-consultant.component.html',
  styleUrls: ['./add-consultant.component.css']
})
export class AddConsultantComponent implements OnInit {

  consultantRequest: ConsultantRequest = {
    name : '',
    yearOfEmployment: 0,
    chargedHours: 0
  };
  addForm: FormGroup;
  
  constructor(
    public modal: NgbActiveModal,
    private consultantService: ConsultantService,
    private formBuilder: FormBuilder
    ) { }

  ngOnInit() {
    this.setForm(this.consultantRequest);
  }

  onSubmit() {
    console.log("Add Form: ", this.addForm.value);

    /*this.consultantRequest.name = this.addForm.value.name;
    this.consultantRequest.yearOfEmployment = this.addForm.value.yearOfEmployment;
    this.consultantRequest.chargedHours = this.addForm.value.chargedHours;*/

    this.consultantService.addConsultant(this.addForm.value).subscribe(x => {
        this.modal.close();
    },
      error => {
        
      });
  }

  get addFormData() { return this.addForm.controls; }

  private setForm(consultant: ConsultantRequest) {
    this.addForm = this.formBuilder.group({
      name: [consultant.name, Validators.required],
      yearOfEmployment: [consultant.yearOfEmployment, Validators.required],
      chargedHours: [ consultant.chargedHours, [Validators.required]]
  });

}
}
