import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NetResult } from 'src/app/models/NetResult';
import { NetResultRequestDto } from 'src/app/models/NetResultRequestDto';
import { NetResultService } from 'src/app/services/net-result.service';

@Component({
  selector: 'app-set-netresult',
  templateUrl: './set-netresult.component.html',
  styleUrls: ['./set-netresult.component.css']
})
export class SetNetresultComponent implements OnInit {

  netResult: NetResult;
  netResultRequestDto: NetResultRequestDto = {
    net : 0
  };
  addForm: FormGroup;

  constructor(
    public modal: NgbActiveModal,
    private netResultService: NetResultService,
    private formBuilder: FormBuilder 
    ) { }

  ngOnInit() {
    this.setForm(this.netResultRequestDto);
  }

  onSubmit() {
    this.netResultRequestDto.net = this.addForm.value.net;
    console.log("Net Result: ",this.netResultRequestDto.net );

    this.netResultService.createNetResult(this.netResultRequestDto).subscribe(x => {
        this.modal.close();
    },
      error => {
        
      });
  }

  get addFormData() { return this.addForm.controls; }

  private setForm(netResultRequestDto: NetResultRequestDto) {
    this.addForm = this.formBuilder.group({
      net: [netResultRequestDto.net, Validators.required]
    });
  }

}
