import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Consultant } from 'src/app/models/Consultant';
import { NetResult } from 'src/app/models/NetResult';
import { ConsultantService } from 'src/app/services/consultant.service';
import { NetResultService } from 'src/app/services/net-result.service';
import { AddConsultantComponent } from '../add-consultant/add-consultant.component';
import { SetNetresultComponent } from '../set-netresult/set-netresult.component';
import { UpdateNetresultComponent } from '../update-netresult/update-netresult.component';

@Component({
  selector: 'app-consultans',
  templateUrl: './consultans.component.html',
  styleUrls: ['./consultans.component.css']
})
export class ConsultansComponent implements OnInit {

  consultants: Consultant[];
  netResult: NetResult;

  constructor(
    private consultantService: ConsultantService,
    private netResultService: NetResultService,
    private modalService: NgbModal
    ) { }

  ngOnInit() {
    this.getNetResult();
    this.getConsultantCollection();
  }
  
  getConsultantCollection() {
    this.consultantService.getConsultantCollection().subscribe((data: Consultant[]) => {
      this.consultants = data;
      console.log(this.consultants);
    }, error => {
      console.log(error);
    });
  }

  getNetResult(){
    this.netResultService.getNetResult().subscribe((data: NetResult) => {
      this.netResult = data;
      console.log("Net Result: ", this.netResult);
    }, error => {
      console.log(error);
    });
  }

  openModal() {
    const ref = this.modalService.open(AddConsultantComponent)

    ref.result.then((yes) => {
      this.getConsultantCollection();
    },
    (cancel) => {
      console.log("Cancel Click");
    })
   }

   openUpdateResultModal(netResult: NetResult) {
    const ref = this.modalService.open(UpdateNetresultComponent)
    ref.componentInstance.netResult = netResult;

    ref.result.then((yes) => {
      this.getConsultantCollection();
      this.getNetResult();
    },
    (cancel) => {
      console.log("Cancel Click");
    })
   }
   
   openSetNetResultModal() {
    const ref = this.modalService.open(SetNetresultComponent)

    ref.result.then((yes) => {
      this.getNetResult();
      this.getConsultantCollection();
    },
    (cancel) => {
      console.log("Cancel Click");
    })
   }

}
