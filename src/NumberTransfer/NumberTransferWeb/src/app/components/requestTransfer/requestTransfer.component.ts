import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ExecuteResponse } from '../../models/responses';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-request-transfer',
  templateUrl: './requestTransfer.component.html',
})
export class RequestTransferComponent {
  owner: string;
  newOwner: string;
  phoneNumber: string;

  httpResult$: Observable<ExecuteResponse>;

  constructor(private readonly blockchainService: BlockchainService) {
  }

  requestTransfer() {
    this.httpResult$ = this.blockchainService.requestTransfer(this.owner, this.phoneNumber, this.newOwner);
  }
}
