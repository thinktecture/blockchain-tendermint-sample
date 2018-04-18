import { Component } from '@angular/core';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
})
export class HeaderComponent {
  party: string;

  constructor(blockchainService: BlockchainService) {
    blockchainService.party$.subscribe(p => this.party = p);
  }
}
