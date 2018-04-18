import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BlockchainService } from '../../services/blockchain.service';

@Component({
  selector: 'app-party',
  templateUrl: './party.component.html',
})
export class PartyComponent implements OnInit {
  party: string;

  constructor(private readonly activatedRoute: ActivatedRoute, private readonly blockchainService: BlockchainService) {
  }

  ngOnInit(): void {
    this.activatedRoute.params
      .subscribe(params => this.setParty(params['name']));
  }

  private setParty(party: string): void {
    this.blockchainService.party = this.party = party[0].toUpperCase() + party.slice(1);
  }
}
