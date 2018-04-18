import { Component } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { ExecuteResponse } from '../../models/responses';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-confirm-transfer-request',
  templateUrl: './confirmTransferRequest.component.html',
})
export class ConfirmTransferRequestComponent {
  newOwner: string;
  phoneNumber: string;

  httpResult$: Observable<ExecuteResponse>;

  constructor(private readonly blockchainService: BlockchainService) {
  }

  confirmTransferRequest() {
    this.httpResult$ = this.blockchainService.confirmTransferRequest(this.phoneNumber, this.newOwner);
  }
}
