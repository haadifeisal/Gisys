import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NetResult } from 'src/app/models/NetResult';
import { NetResultRequestDto } from 'src/app/models/NetResultRequestDto';
import { NetResultService } from 'src/app/services/net-result.service';

@Component({
  selector: 'app-update-netresult',
  templateUrl: './update-netresult.component.html',
  styleUrls: ['./update-netresult.component.css']
})
export class UpdateNetresultComponent implements OnInit {

  netResult: NetResult;
  netResultRequestDto: NetResultRequestDto = {
    net : 0
  };
  editForm: FormGroup;

  constructor(
    public modal: NgbActiveModal,
    private netResultService: NetResultService,
    private formBuilder: FormBuilder 
    ) { }

  ngOnInit() {
    this.setForm(this.netResult);
  }

  onSubmit() {
    this.netResultRequestDto.net = this.editForm.value.net;
    console.log("Net Result: ",this.netResultRequestDto.net );

    this.netResultService.updateNetResult(this.netResult.netResultId, this.netResultRequestDto).subscribe(x => {
        this.modal.close();
    },
      error => {
        
      });
  }

  get editFormData() { return this.editForm.controls; }

  private setForm(netResult: NetResult) {
    this.editForm = this.formBuilder.group({
      net: [netResult.net, [Validators.required, Validators.min(1)]]
    });
  }

}
