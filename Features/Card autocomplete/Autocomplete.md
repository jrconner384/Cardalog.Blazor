# Card autocomplete

If a card already exists, the user should be able to select it when creating a copy so they don't have to fill out the entire form.

- [Card autocomplete](#card-autocomplete)
  - [Results list](#results-list)
  - [Frequency of update](#frequency-of-update)
    - [Timer mechanic](#timer-mechanic)
  - [Results set](#results-set)
    - [Case study: Ember Mage](#case-study-ember-mage)
      - [Condition research](#condition-research)
  - [Filling the form](#filling-the-form)

## Results list

As the user types in the card title, a list of matches will be presented.

Requirements:

1. The list will be sorted alphabetically.
2. The results will be those cards with title starting with the contents of the text box.
   1. For example, use `StartsWith` to create the list of results.
3. When the user hovers over a result, the card's info will be displayed.
   1. Consider using `CardDisplayCard.razor` in a tooltip to render the results.
4. The list will be scrollable.
5. If an option is clicked, the form will autopopulate with that card's info.
   1. It will _not_ set the card's condition.
   2. It will _not_ save the card automatically.
   3. The user will be able to edit the form.
   4. If the user edits the title, the autocomplete feature must continue working. If a new card is selected, _every_ field in the form must be overwritten.
6. The results list must not be visible when the title text box does not have focus.
7. The results will be a set (i.e. no duplicates).

## Frequency of update

The frequency will be dictated by the client's performance. I'll have to eyeball this as I implement the feature. My instinct is to update the list on every keystroke. Since the list of cards is already present on the client, this won't cause chatter between the client and the API. I have no idea how this will perform on arbitrarily large datasets, so I may need to add a delay which determines that the user hasn't typed for _m_ milliseconds before updating the list.

I may also wait until a few characters have been typed before creating the list the first time. The longer the search string, the shorter the list of results, the better the performance. The one caveat is cards with short names. The shortest card name I can think of is three characters but there may be shorter names. It might be necessary to get the results for shorter strings after _m_ milliseconds.

### Timer mechanic

I have to be careful about using a timer. It smells like the kind of thing that could become overengineered.

## Results set

The list must not contain duplicates. A card can be part of more than one expansion and, for now, I want those to be treated like unique cards. Cards with the same title but different conditions, however, are not distinct.

### Case study: Ember Mage

- There's a card called Ember Mage.
- It belongs to the expansions Alpha and Beta.
- From Alpha, the database has two near mint and one good copy.
- From Beta, the database has one fair and one poor copy.
- I'm adding a new copy of the card.
- I've typed "Ember" into the Title text box in the new card form.

I expect the results list to include two named "Ember Mage" and any other cards starting with "Ember". I'm not prescribing the UI here, but it will be something like this.

+--------------------+
| Ember Mage (Alpha) |
| Ember Mage (Beta)  |
| Embers (Starter)   |
| Emberstorm (Alpha) |
+--------------------+

The client application already has a collection of cards in memory (**note** it might be a good idea to call the API to update the collection when the new card form is opened). The collection needs to be filtered a few ways.

In pseudo-code, the first filter is `var results = cards.Where(card.Title.StartsWith(titleBoxValue, Options.IgnoreCase))`. In English, the list will first be narrowed down to those cards with titles starting with the value in the title text box. Case will not be considered when making this comparison.

**Stretch goal:** the initial implementation should only match the beginning of the card titles. For example, since I typed "Ember" into the title box, "Ember Mage" will be in the list but "Burn to Embers" will not. A more sophisticated approach will find matches at any position in the title so both Ember Mage and Burn to Embers will be included.

The results then need to be reduced to only distinct elements. To use `Distinct()`, `Card.cs` needs to implement `IEquatable<Card>`. Off the cuff, it might look like this (pseudo-C#):

```cs
public bool Equals(Card other)
{
  return Title.Equals(other.Title, Options.IgnoreCase) && Expansion.Name.Equals(other.Expansion.Name, Options.IgnoreCase);
}

public override int GetHashCode()
{
  var hashTitle = Title == null ? 0 : Title.GetHashCode();
  var hashExpansion = Expansion.Name == null ? 0 : Expansion.Name.GetHashCode();
  return hashTitle ^ hashExpansion;
}
```

#### Condition research

I need to figure out if implementing the above is sufficient or condition leads to duplicates.

## Filling the form

I can't decide whether a click or double click is the right gesture but, either way, one of them will populate the form with the chosen card's data. The title text box should lose focus so the results list will be dismissed.
