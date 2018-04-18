import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ExecuteResponse } from '../../models/responses';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-deny-transfer-request',
  templateUrl: './denyTransferRequest.component.html',
})
export class DenyTransferRequestComponent {
  newOwner: string;
  phoneNumber: string;

  httpResult$: Observable<ExecuteResponse>;

  constructor(private readonly blockchainService: BlockchainService) {
  }

  denyTransferRequest() {
    this.httpResult$ = this.blockchainService.denyTransferRequest(this.phoneNumber, this.newOwner);
  }
}
